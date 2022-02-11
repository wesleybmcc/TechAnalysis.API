using Microsoft.EntityFrameworkCore;

namespace TechAnalysis.Data
{
    public class TechAlertDbContext : DbContext
    {
        public DbSet<Instrument>? Instrument { get; set; }
        public DbSet<InstrumentType>? InstrumentType { get; set; }
        public DbSet<TechnicalType>? TechnicalType { get; set; }
        public DbSet<TechnicalFeature>? TechnicalFeature { get; set; }
        public DbSet<DailyPrice>? DailyPrice { get; set; }
        public DbSet<Market>? Market { get; set; }

        public TechAlertDbContext(DbContextOptions<TechAlertDbContext> options)
            : base(options)
        {
        }
    }

    public class Instrument
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? Description { get; set; }
        public int MarketId { get; set; }
        public bool Active { get; set; }
        public virtual Market? Market { get; set; }
    }

    public class InstrumentType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class TechnicalType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class TechnicalFeature
    {
        public int Id { get; set; }
        public int TechnicalTypeId { get; set; }
        public string? Name { get; set; }
    }

    public class DailyPrice
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public System.DateTime Date { get; set; }
        public virtual Instrument? Instrument { get; set; }
    }

    public class Market
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sector { get; set; }
    }
}
