using Microsoft.AspNetCore.Mvc;
using WebApplication1.HelperServices;
using WebApplication1.Services.Models;

namespace ShopSchema.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _service;

    #region Constructor
    
    public ProductController(IProductService service)
    {
        _service = service;
    }
    
    #endregion


    #region Methods
    
    public IActionResult Index()
    {
        return View();
    }
    
    
    public IActionResult Dishwasher()
    {
        var collection = _service.SelectAll(NameList.dishwasher.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Iphone()
    {
        var collection = _service.SelectAll(NameList.Iphone.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult MSI()
    {
        var collection = _service.SelectAll(NameList.MSI.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Music()
    {
        var collection = _service.SelectAll(NameList.MoonlightSonata_Beethoven_in_B_minor.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Nvidea()
    {
        var collection = _service.SelectAll(NameList.GTX_1080.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Samsung()
    {
        var collection = _service.SelectAll(NameList.Samsung.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Scarlett()
    {
        var collection = _service.SelectAll(NameList.Scarlett_comfort.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Sony()
    {
        var collection = _service.SelectAll(NameList.Sony_ps4.ToString()).ToList();
        return View(collection);
    }
    
    
    public IActionResult Tesla()
    {
        var collection = _service.SelectAll(NameList.Tesla.ToString()).ToList();
        return View(collection);
    }
    
    #endregion
}