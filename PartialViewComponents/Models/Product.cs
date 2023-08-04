namespace PartialViewComponents.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }  

    }
}
