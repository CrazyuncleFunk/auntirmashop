using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aunt_Irma_Shop.Models;
using Aunt_Irma_Shop.Models.ViewModels;
using Aunt_Irma_Shop.Data;
using Microsoft.EntityFrameworkCore;

namespace Aunt_Irma_Shop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }
      

        public async Task<IActionResult> Index()
        {
            IndexViewModel indexVM = new IndexViewModel
            {
                Category = await _db.Category.ToListAsync(),
                SubCategory = await _db.SubCategory.ToListAsync(),
                Item = await _db.Item.Include(i => i.Category).Include(i => i.SubCategory).ToListAsync()
            };
            return View(indexVM);
        }

        public async  Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Item item = await _db.Item.Include(s => s.Category).Include(s => s.SubCategory).FirstOrDefaultAsync(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
