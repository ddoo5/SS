using Microsoft.AspNetCore.Mvc;

namespace ShopSchema.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Delete()
    {
        return View();
    }
}