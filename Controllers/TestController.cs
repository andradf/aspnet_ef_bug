using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConcurrencyBug.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConcurrencyBug.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private ApplicationDbContext dbContext;
        //private UserManager<ApplicationUser> userManager;

        public TestController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("{id}")]
        public async Task GetAction1(string name)
        {
            await dbContext.People.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}