using WebApplication1.DB.Models;

namespace WebApplication1.Reports.Models
{
    public class ProductGeneratorModel
    {
        public string Name { get; set; } = null!;
        public int Bill { get; set; } = 0;
        public string Address { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; }
    }
}

