using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopSchema.Controllers;

public class OrderController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Delete()
    {
        return View();
    }
}