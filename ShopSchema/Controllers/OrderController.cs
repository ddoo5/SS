using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopSchema.Models;
using WebApplication1.Reports.Class;
using WebApplication1.Reports.Interface;
using WebApplication1.Reports.Models;
using WebApplication1.Services.Models;

namespace ShopSchema.Controllers;

public class OrderController : Controller
{
    private readonly IProductService _service;


    public OrderController(IProductService service)
    {
        _service = service;
    }
    
    
    [Authorize]
    public IActionResult Index(int billNumber, string buyerName, string productName, int price)
    {
        CartKeep keep = new CartKeep();
        keep.Bill = billNumber;
        keep.Buyer = buyerName;
        keep.Product = productName;
        keep.Price = price;
        
        return View(keep);
    }
    
    
    [Authorize]
    public IActionResult Create(int billNumber, string buyerName, string productName, int price)
    {
        IProductReportGenerator report = new ProductReportGenerator("Reports/Template/WaterTemplate.docx");
        Random rnd = new();
        if (billNumber == 0)
            billNumber = rnd.Next(1, 999);
        var catalog = new ProductGeneratorModel
        {
            Name = "LLC Local Company",
            Bill = billNumber,
            Address = "St.P.",
            Products = _service.SelectItem(productName, price)
        };
            
        _service.CreateReport(buyerName, report, catalog, $"Reports/Generated/{billNumber}_Bill.docx");
        
        return View();
    }
}