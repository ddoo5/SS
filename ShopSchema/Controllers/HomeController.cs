using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShopSchema.Models;
using WebApplication1.Services.Models;

namespace ShopSchema.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _service;

    #region Constructor
    
    public HomeController(IProductService service)
    {
        _service = service;
    }
    
    #endregion

    public IActionResult Index()
    {
        var collection = _service.SelectFourItems().ToList();
        return View(collection);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}