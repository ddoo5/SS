using WebApplication1.DB.Connections;
using WebApplication1.DB.Models;
using WebApplication1.Reports.Interface;
using WebApplication1.Reports.Models;
using WebApplication1.Services.Models;

namespace WebApplication1.Services.Implimentations;

public class ProductService : IProductService
{
    #region Services
    
    private readonly ILogger<ProductService> _logger;
    private readonly DBConnection _connection;

    #endregion
    
    
    #region Constructors

    public ProductService(DBConnection connection, ILogger<ProductService> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    #endregion


    #region Methods

    public Product Create(decimal price, string name)
    {
        var id = _connection.Products.Count() + 1;
        
        var product = new Product
        {
            Id =  id,
            Price = price,
            Category = "товар",
            Name = name
        };

        _connection.Products.Add(product);
        
        _connection.SaveChanges();

        return product;

    }


    public IEnumerable<Product> SelectAll(string itemName)
    {
        return _connection.Products.Where(x => x.Name == itemName).ToList();
    }
    
    
    public IEnumerable<Product> SelectFourItems()
    {
        Random rnd = new();
        
        return _connection.Products
                .Skip(rnd.Next(1,4))
                .Take(rnd.Next(5,9))
                .Where(x => x.Id != null)
                .ToList();
    }


    public void CreateReport(string buyer, IProductReportGenerator reportGenerator, ProductGeneratorModel catalog, string reportFileName)
    {
        reportGenerator.CompanyName = catalog.Name;
        reportGenerator.BillNumber = catalog.Bill;
        reportGenerator.CompanyAddres = catalog.Address;
        reportGenerator.Date = DateTime.Now;
        reportGenerator.BuyerName = buyer;
        reportGenerator.Products = catalog.Products.Select(product => (product.Id, product.Name, product.Category, product.Price));

        FileInfo reportFileInfo = reportGenerator.Create(reportFileName);
    }

    #endregion
}