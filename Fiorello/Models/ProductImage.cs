

namespace Fiorello.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        public bool IsMain { get; set; }
    }
}
