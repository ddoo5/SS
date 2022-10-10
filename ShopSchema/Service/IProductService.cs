using WebApplication1.DB.Models;
using WebApplication1.Reports.Interface;
using WebApplication1.Reports.Models;

namespace WebApplication1.Services.Models;

public interface IProductService
{ 
    Product Create(decimal price, string name);

    IEnumerable<Product> SelectAll(string itemName);

    IEnumerable<Product> SelectItem(string itemName, int price);

    IEnumerable<Product> SelectFourItems();

    void CreateReport(string buyer, IProductReportGenerator reportGenerator, ProductGeneratorModel catalog,
        string reportFileName, int billNumber);
}