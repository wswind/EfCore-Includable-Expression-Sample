using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfcoreIncludeDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Internal;
using EfcoreIncludeDemo.Application;
using EfcoreIncludeDemo.ForIncludes;

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
            var lst = GetAllWithIncludes(x => x.Include(y => y.Model2).ThenInclude(z => z.Model3));
            return Ok("debug here");
        }

        private List<Model1> GetAllWithIncludes(Func<IIncludable<Model1>, IIncludable> includes)
        {
            return demoDbContext.Model1s
                .IncludeMultiple(includes)
                .ToList();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
