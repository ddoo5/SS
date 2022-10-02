using WebApplication1.DB.Models;

namespace WebApplication1.HelperServices;

public interface IGhostUser
{
    Task<Product> Create();
}