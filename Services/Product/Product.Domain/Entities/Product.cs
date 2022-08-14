using ProductService.Domain.Common;

namespace ProductService.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public bool Reserved { get; set; }
        public int Amount { get; set; }
    }
}
