using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aunt_Irma_Shop.Data;
using Aunt_Irma_Shop.Models;
using Aunt_Irma_Shop.Models.ViewModels;
using Aunt_Irma_Shop.Utillity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aunt_Irma_Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }
        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: SubCategory
        public async Task<ActionResult> Index()
        {
            var subCategoryList = await _db.SubCategory.Include(s => s.Category).ToListAsync();
            return View(subCategoryList);
        }

        // GET: SubCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubCategory subCategory = await _db.SubCategory.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategory/Create
        public async Task<ActionResult> Create()
        {
            CategoryAndSubCategoryViewModel model = new CategoryAndSubCategoryViewModel
            {
                CategoryList = await _db.Category.ToListAsync(),
                SubCategory = new Models.SubCategory(),
                SubCategoryList = await _db.SubCategory.OrderBy(s=>s.Name).Select(s=>s.Name).ToListAsync()
            };
            return View(model);
        }

        // POST: SubCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryAndSubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subCategory = _db.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);

                if(subCategory.Count() > 0)
                {
                    StatusMessage = "Error : SubCategory Already Exists";
                }
                else
                {
                    _db.SubCategory.Add(model.SubCategory);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            CategoryAndSubCategoryViewModel modelVm = new CategoryAndSubCategoryViewModel
            {
                CategoryList = await _db.Category.ToListAsync(),
                SubCategory = model.SubCategory,
                SubCategoryList = await _db.SubCategory.OrderBy(s => s.Name).Select(s => s.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVm);
        }

        // GET: SubCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubCategory subCategory = await _db.SubCategory.Include(s=>s.Category).FirstOrDefaultAsync(s=>s.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            CategoryAndSubCategoryViewModel model = new CategoryAndSubCategoryViewModel
            {
                CategoryList = await _db.Category.ToListAsync(),
                SubCategory = subCategory,
                SubCategoryList = await _db.SubCategory.OrderBy(s => s.Name).Select(s => s.Name).ToListAsync()
            };
            return View(model);
            
        }

        // POST: SubCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                    _db.Update(subCategory);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }

            return View(subCategory);

        }

        // GET: SubCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             SubCategory subCategory = await _db.SubCategory.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var subCategory = await _db.SubCategory.FindAsync(id);

            if (subCategory == null)
            {
                return View();
            }

            _db.Remove(subCategory);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await (from SubCategory in _db.SubCategory
                                   where SubCategory.CategoryId == id
                                   select SubCategory).ToListAsync();
            return Json(new SelectList(subCategories, "Id", "Name"));
        }
    }
}