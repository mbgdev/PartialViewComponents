using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialViewComponents.Data;

namespace PartialViewComponents.Components
{
    public class CategoryList:ViewComponent
    {
        private readonly AppDbContext _context;

        public CategoryList(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.ToListAsync());
        }

    }
}
