using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aunt_Irma_Shop.Data;
using Aunt_Irma_Shop.Models;
using Aunt_Irma_Shop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Aunt_Irma_Shop.Utillity;

namespace Aunt_Irma_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public string StatusMessage { get; set; }
        [BindProperty]
        public ItemViewModel ItemVM { get; set; }
        public ItemController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            ItemVM = new ItemViewModel()
            {
                CategoryList = _db.Category,
                Item = new Models.Item()
            };
        }
        // GET: MenuItem
        public async Task<ActionResult> Index()
        {
            var menuItemList = await _db.Item.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return View(menuItemList);
        }

        // GET: MenuItem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Item menuItem = await _db.Item.Include(s => s.Category).Include(s => s.SubCategory).FirstOrDefaultAsync(s => s.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        // GET: MenuItem/Create
        public ActionResult Create()
        {
           
            return View(ItemVM);
        }

        // POST: MenuItem/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePost()
        {
            ItemVM.Item.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());
            if (!ModelState.IsValid) 
            {
                return View(ItemVM);
            }
            
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    ItemVM.Item.Picture = p1;
                }
                
                _db.Item.Add(ItemVM.Item);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ItemVM);
        }

        // GET: MenuItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ItemVM.Item = await _db.Item.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefaultAsync(m => m.Id == id);
            ItemVM.SubCategoryList = await _db.SubCategory.Where(s => s.CategoryId == ItemVM.Item.CategoryId).ToListAsync();
            if (ItemVM.Item == null)
            {
                return NotFound();
            }
            return View(ItemVM);
        }

        // POST: MenuItem/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ItemVM.Item.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                ItemVM.SubCategoryList = await _db.SubCategory.Where(s => s.CategoryId == ItemVM.Item.CategoryId).ToListAsync();
                return View(ItemVM);
            }

            //Work on the image saving section

            var ItemFromDb = await _db.Item.FindAsync(ItemVM.Item.Id);
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    ItemFromDb.Picture = p1;
                }

                ItemFromDb.Name = ItemVM.Item.Name;
                ItemFromDb.Description = ItemVM.Item.Description;
                ItemFromDb.Price = ItemVM.Item.Price;
                ItemFromDb.CategoryId = ItemVM.Item.CategoryId;
                ItemFromDb.SubCategoryId = ItemVM.Item.SubCategoryId;

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ItemVM);
        }

        // GET: MenuItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Item item = await _db.Item.Include(s => s.Category).Include(s => s.SubCategory).FirstOrDefaultAsync(s => s.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var ItemFromDb = await _db.Item.FindAsync(id);
            _db.Remove(ItemFromDb);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}