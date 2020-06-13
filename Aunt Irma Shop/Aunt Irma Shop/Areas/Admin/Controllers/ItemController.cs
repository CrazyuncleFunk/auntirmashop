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
            _db.Item.Add(ItemVM.Item);
            await _db.SaveChangesAsync();

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _db.Item.FindAsync(ItemVM.Item.Id);

            if (files.Count > 0)
            {
                //files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, ItemVM.Item.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemFromDb.Image = @"\images\" + ItemVM.Item.Id + extension;
            }
            else
            {
                //no file was uploaded, so use default
                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + ItemVM.Item.Id + ".png");
                menuItemFromDb.Image = @"\images\" + ItemVM.Item.Id + ".png";
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _db.Item.FindAsync(ItemVM.Item.Id);

            if (files.Count > 0)
            {
                //New Image has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension_new = Path.GetExtension(files[0].FileName);

                //Delete the original file
                var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                //we will upload the new file
                using (var filesStream = new FileStream(Path.Combine(uploads, ItemVM.Item.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemFromDb.Image = @"\images\" + ItemVM.Item.Id + extension_new;
            }

            menuItemFromDb.Name = ItemVM.Item.Name;
            menuItemFromDb.Description = ItemVM.Item.Description;
            menuItemFromDb.Price = ItemVM.Item.Price;
            menuItemFromDb.CategoryId = ItemVM.Item.CategoryId;
            menuItemFromDb.SubCategoryId = ItemVM.Item.SubCategoryId;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: MenuItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           

            //Work on the image saving section

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _db.Item.FindAsync(id);


            if (!ModelState.IsValid)
            {

                return View(menuItemFromDb);
            }

            //Delete the original file
            var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

            _db.Remove(menuItemFromDb);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}