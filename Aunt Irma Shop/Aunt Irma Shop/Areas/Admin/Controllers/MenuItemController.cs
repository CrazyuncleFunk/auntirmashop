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
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public string StatusMessage { get; set; }
        [BindProperty]
        public CategorySubCategoryandMenuItemViewModel categorySubCategoryandMenuItemViewModel { get; set; }
        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            categorySubCategoryandMenuItemViewModel = new CategorySubCategoryandMenuItemViewModel()
            {
                CategoryList = _db.Category,
                MenuItem = new Models.MenuItem()
            };
        }
        // GET: MenuItem
        public async Task<ActionResult> Index()
        {
            var menuItemList = await _db.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return View(menuItemList);
        }

        // GET: MenuItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuItem/Create
        public ActionResult Create()
        {
           
            return View(categorySubCategoryandMenuItemViewModel);
        }

        // POST: MenuItem/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePost()
        {
            categorySubCategoryandMenuItemViewModel.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());
            if (!ModelState.IsValid) 
            {
                return View(categorySubCategoryandMenuItemViewModel);
            }
            _db.MenuItem.Add(categorySubCategoryandMenuItemViewModel.MenuItem);
            await _db.SaveChangesAsync();

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _db.MenuItem.FindAsync(categorySubCategoryandMenuItemViewModel.MenuItem.Id);

            if (files.Count > 0)
            {
                //files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, categorySubCategoryandMenuItemViewModel.MenuItem.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemFromDb.Image = @"\images\" + categorySubCategoryandMenuItemViewModel.MenuItem.Id + extension;
            }
            else
            {
                //no file was uploaded, so use default
                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + categorySubCategoryandMenuItemViewModel.MenuItem.Id + ".png");
                menuItemFromDb.Image = @"\images\" + categorySubCategoryandMenuItemViewModel.MenuItem.Id + ".png";
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
            categorySubCategoryandMenuItemViewModel.MenuItem = await _db.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefaultAsync(m => m.Id == id);
            categorySubCategoryandMenuItemViewModel.SubCategoryList = await _db.SubCategory.Where(s => s.CategoryId == categorySubCategoryandMenuItemViewModel.MenuItem.CategoryId).ToListAsync();
            if (categorySubCategoryandMenuItemViewModel.MenuItem == null)
            {
                return NotFound();
            }
            return View(categorySubCategoryandMenuItemViewModel);
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
            categorySubCategoryandMenuItemViewModel.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                categorySubCategoryandMenuItemViewModel.SubCategoryList = await _db.SubCategory.Where(s => s.CategoryId == categorySubCategoryandMenuItemViewModel.MenuItem.CategoryId).ToListAsync();
                return View(categorySubCategoryandMenuItemViewModel);
            }

            //Work on the image saving section

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _db.MenuItem.FindAsync(categorySubCategoryandMenuItemViewModel.MenuItem.Id);

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
                using (var filesStream = new FileStream(Path.Combine(uploads, categorySubCategoryandMenuItemViewModel.MenuItem.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemFromDb.Image = @"\images\" + categorySubCategoryandMenuItemViewModel.MenuItem.Id + extension_new;
            }

            menuItemFromDb.Name = categorySubCategoryandMenuItemViewModel.MenuItem.Name;
            menuItemFromDb.Description = categorySubCategoryandMenuItemViewModel.MenuItem.Description;
            menuItemFromDb.Price = categorySubCategoryandMenuItemViewModel.MenuItem.Price; 
            menuItemFromDb.CategoryId = categorySubCategoryandMenuItemViewModel.MenuItem.CategoryId;
            menuItemFromDb.SubCategoryId = categorySubCategoryandMenuItemViewModel.MenuItem.SubCategoryId;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: MenuItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}