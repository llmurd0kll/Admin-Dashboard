namespace Denisov.AdminDashboardTask.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public virtual Client Client { get; set; } // Связь one-to-many с Client
    }
}
