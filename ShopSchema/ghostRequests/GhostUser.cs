using WebApplication1.DB.Models;
using WebApplication1.Services.Models;

namespace WebApplication1.HelperServices;

public class GhostUser : IGhostUser
{
    private  readonly IProductService _service;


    public GhostUser()
    {
    }
    
    public GhostUser(IProductService service)
    {
        _service = service;
    }
    
    
    public async Task<Product> Create()   //without logic, full random
    {
        //data
        Random rnd = new();

        //method
        for (int i = 0; i < rnd.Next(100,500); i++)
        {
            //add
            _service.Create(rnd.Next(15000, 30000), NameList.dishwasher.ToString());
            _service.Create(rnd.Next(75000, 145000), NameList.Iphone.ToString());
            _service.Create(rnd.Next(30000, 125000), NameList.Samsung.ToString());
            _service.Create(rnd.Next(1500, 8990), NameList.Scarlett_comfort.ToString());
            _service.Create(rnd.Next(15000, 20000), NameList.Sony_ps4.ToString());
            _service.Create(rnd.Next(5600000, 10000000), NameList.Tesla.ToString());
            _service.Create(rnd.Next(40000, 80000), NameList.GTX_1080.ToString());
            _service.Create(rnd.Next(40000, 180000), NameList.MSI.ToString());
            _service.Create(rnd.Next(200, 1000), NameList.MoonlightSonata_Beethoven_in_B_minor.ToString());
        }
        
        return new Product(){};
    } 
}