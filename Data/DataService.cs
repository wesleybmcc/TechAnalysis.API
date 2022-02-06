namespace TechAnalysis.Data
{
    public abstract class DataService
    {
        protected readonly TechAlertDbContext _context;
        protected DataService(TechAlertDbContext context)
        {
            this._context = context;
        }
    }
}
