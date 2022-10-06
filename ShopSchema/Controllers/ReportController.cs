using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ShopSchema.Controllers;

public class ReportController : Controller
{
    
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}