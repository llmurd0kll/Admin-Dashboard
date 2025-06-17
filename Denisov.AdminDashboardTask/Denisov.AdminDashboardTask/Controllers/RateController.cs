using Denisov.AdminDashboardTask.Database.Context;
using Denisov.AdminDashboardTask.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Denisov.AdminDashboardTask.Controllers
{
    public class RateController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RateController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<Rate>> GetRate()
        {
            try
            {
                var rate = await _dbContext.Rates.LastOrDefaultAsync();
                if (rate == null)
                {
                    return NotFound("Rate not found.");
                }
                return Ok(rate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving rate: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRate([FromBody] Rate rate)
        {
            try
            {
                if (rate == null || rate.RateValue <= 0)
                {
                    return BadRequest("Invalid rate data.");
                }

                var existingRate = await _dbContext.Rates.LastOrDefaultAsync(); //Important: Get the existing rate

                if (existingRate == null)
                {
                    //Handle case where there's no existing rate (e.g. create one)
                    existingRate = new Rate { Id = 1, RateValue = rate.RateValue };
                    _dbContext.Rates.Add(existingRate);
                }
                else
                {
                    existingRate.RateValue = rate.RateValue; // Update the existing rate
                }

                await _dbContext.SaveChangesAsync();

                return Ok(); // Indicate success
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating rate: {ex.Message}");
            }
        }
    }
}
