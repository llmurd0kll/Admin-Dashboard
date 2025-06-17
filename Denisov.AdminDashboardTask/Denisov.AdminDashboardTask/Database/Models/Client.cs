namespace Denisov.AdminDashboardTask.Database.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Balance { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>(); // Added for one-to-many
    }
}
