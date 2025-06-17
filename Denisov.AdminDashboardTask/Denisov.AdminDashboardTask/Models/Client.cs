namespace Denisov.AdminDashboardTask.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Нельзя null, required
        public string Email { get; set; } = null!; // Нельзя null, required
        public decimal Balance { get; set; }
    }
}
