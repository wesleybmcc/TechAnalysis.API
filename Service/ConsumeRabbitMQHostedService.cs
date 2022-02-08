using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TechAnalysis.Hub;
using TechAnalysis.Model;

namespace TechAnalysis.API.Service
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly ILogger _logger;
        private IConnection _connection;
        private IModel _channel;

        public ConsumeRabbitMQHostedService(ILoggerFactory loggerFactory, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._logger = loggerFactory.CreateLogger<ConsumeRabbitMQHostedService>();
            this._hubContext = hubContext;

            var factory = new ConnectionFactory { HostName = "localhost" };
            // create connection
            _connection = factory.CreateConnection();

            // create channel
            _channel = _connection.CreateModel();

            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            _channel.ExchangeDeclare("demo.exchange", ExchangeType.Topic);
            _channel.QueueDeclare("demo.queue.log", false, false, false, null);
            _channel.QueueBind("hello", "demo.exchange", "demo.queue.*", null);
            _channel.BasicQos(0, 1, false);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());

                // handle the received message
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume("hello", false, consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            // we just print this message 
            _logger.LogInformation($"consumer received {content}");
            _hubContext.Clients.All.SendMessage("PriceUpdate", content);
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            _logger.LogInformation($"connection shut down {e.ReplyText}");
        }

        private void OnConsumerConsumerCancelled(object? sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer cancelled {e.ConsumerTags}");
        }

        private void OnConsumerUnregistered(object? sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer unregistered {e.ConsumerTags}");
        }

        private void OnConsumerRegistered(object? sender, ConsumerEventArgs e)
        {
            _logger.LogInformation($"consumer registered {e.ConsumerTags}");
        }

        private void OnConsumerShutdown(object? sender, ShutdownEventArgs e)
        {
            _logger.LogInformation($"consumer shutdown {e.ReplyText}");
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
