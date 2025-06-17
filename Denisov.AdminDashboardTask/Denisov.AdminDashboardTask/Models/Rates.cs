namespace Denisov.AdminDashboardTask.Models
{
    public class Rate
    {
        public int Id { get; set; } //Primary key
        public decimal RateValue { get; set; }
        public DateTime LastUpdated { get; set; } //Important for tracking
    }
}
