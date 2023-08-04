using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace PartialViewComponents.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
     
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
