using Microsoft.AspNetCore.Mvc.Rendering;
using PartialViewComponents.Models;

namespace PartialViewComponents.ViewModels
{
    public class ProductVM
    {

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem>? CategorySelectList { get; set; }

    }
}
