using Denisov.AdminDashboardTask.Database.Context;
using Denisov.AdminDashboardTask.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Denisov.AdminDashboardTask.Controllers
{
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            try
            {
                var clients = await _dbContext.Clients.ToListAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                // Log the exception (very important in production)
                // Consider returning a more specific error response
                return StatusCode(500, $"Error retrieving clients: {ex.Message}");
            }
        }
    }

}
