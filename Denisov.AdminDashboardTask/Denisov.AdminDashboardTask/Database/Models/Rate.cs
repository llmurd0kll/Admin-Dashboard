namespace Denisov.AdminDashboardTask.Database.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public decimal RateValue { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
