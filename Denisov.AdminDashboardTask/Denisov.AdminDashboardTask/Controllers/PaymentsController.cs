using Denisov.AdminDashboardTask.Database.Context;
using Denisov.AdminDashboardTask.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Denisov.AdminDashboardTask.Controllers
{
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments([FromQuery] int? take = 5)
        {
            try
            {
                var payments = await _dbContext.Payments
                    .OrderByDescending(p => p.Date)
                    .Take(take ?? 5)
                    .ToListAsync();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving payments: {ex.Message}");
            }
        }

    }
}
