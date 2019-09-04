using EfcoreIncludeDemo.ForIncludes;
using EfcoreIncludeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfcoreIncludeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoDbContext demoDbContext;

        public HomeController(DemoDbContext demoDbContext)
        {
            this.demoDbContext = demoDbContext;
        }
        

        public IActionResult Index()
        {
            var query = demoDbContext.Model1S.IncludeMultiple(x => x.Include(y => y.Model2).ThenInclude(z => z.Model3).ThenInclude(m=>m.Model4));
            var list = query.ToList();
            return Ok("debug here");
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
