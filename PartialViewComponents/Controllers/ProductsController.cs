using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartialViewComponents.Data;
using PartialViewComponents.Models;
using PartialViewComponents.ViewModels;

namespace PartialViewComponents.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var model = new ProductVM();
            model.CategorySelectList = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();

            //var categoryList = (from q in _context.Categories
            // select new SelectListItem
            // {
            //     Text = q.Name,
            //     Value = q.CategoryId.ToString(),
            // }).ToList();

            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productVM)
        {



            if (ModelState.IsValid)
            {
                Product product = new();

                product.Name= productVM.Name;

                product.Description= productVM.Description;

                product.Price= productVM.Price;

                product.ImageUrl= productVM.ImageUrl;

                product.CreatedTime= DateTime.Now;

                product.ModifiedTime= DateTime.Now;

                product.CategoryId=productVM.CategoryId;



                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var model = new ProductVM();
            model.CategorySelectList = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();

            productVM.CategorySelectList=model.CategorySelectList;
            return View(productVM);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            var model=new ProductVM();

            model.ProductId= product.ProductId;

            model.Name = product.Name;
          
            model.Description = product.Description;
            
            model.Price = product.Price;
            
            model.ImageUrl = product.ImageUrl;
                 
            model.CategoryId = product.CategoryId;

            model.CategorySelectList = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( ProductVM productVM)
        {
            

            if (ModelState.IsValid)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x=>x.ProductId==productVM.ProductId);


                var state = _context.Entry(product).State;

                product.Name = productVM.Name;

                product.Description = productVM.Description;

                product.Price = productVM.Price;

                product.ImageUrl = productVM.ImageUrl;

                product.ModifiedTime = DateTime.Now;

                product.CategoryId = productVM.CategoryId;

                product.ModifiedTime = DateTime.Now;

                //   _context.Update(product);

                state = _context.Entry(product).State;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
