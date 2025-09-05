namespace DataAccess.Models
{
    public abstract class BaseClass
    {
        public long Id { get; set; }

        public DateTime KayıtTarihi { get; set; } = DateTime.UtcNow;
    }
}
