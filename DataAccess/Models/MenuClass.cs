namespace DataAccess.Models
{
    public class MenuClass : BaseClass
    {
        public string MenuAdi { get; set; } = string.Empty;
        public long ParentId { get; set; }
    }
}
