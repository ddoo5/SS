namespace WebApplication1.Reports.Interface
{
    public interface IProductReportGenerator
    {
        string CompanyName { get; set; }
        string CompanyAddres { get; set; }
        int BillNumber { get; set; }
        DateTime Date { get; set; }
        string BuyerName { get; set; }
        IEnumerable<(int? Id, string Name, string? Category, decimal? Price)> Products { get; set; }

        FileInfo Create(string reportFilePath);
    }
}

