using TemplateEngine.Docx;
using WebApplication1.Reports.Interface;

namespace WebApplication1.Reports.Class
{
    public class ProductReportGenerator : IProductReportGenerator
    {
        #region Private

        private readonly string _FieldCompanyName = "CompanyName";
        private readonly string _FieldDateOfCreation = "Date";
        private readonly string _FieldNumberOfBill = "Bill";  //rename to number
        private readonly string _FieldBuyerName = "Client";  //rename to buyername
        private readonly string _FieldCompanyAddres = "CompanyAddres";
        private readonly string _FieldBill = "ToPay";
        private readonly string _FieldLogo = "Logo";

        private readonly string _FieldProduct = "Product";
        private readonly string _FieldProductId = "ProductId";
        private readonly string _FieldProductPrice = "ProductPrice";
        private readonly string _FieldProductcategory = "ProductCategory";
        private readonly string _FieldProductName = "ProductName";

        private readonly FileInfo _template;

        #endregion


        #region Public

        public string CompanyName { get; set; } = null!;
        public string CompanyAddres { get; set; } = null!;
        public int BillNumber { get; set; } = 0;
        public DateTime Date { get; set; }
        public string BuyerName { get; set; } = null!;
        public IEnumerable<(int? Id, string Name, string? Category, decimal? Price)> Products { get; set; }

        #endregion


        #region Constructor

        public ProductReportGenerator(string templatefile)
        {
            _template = new FileInfo(templatefile);
        }

        #endregion


        #region methods

        public FileInfo Create(string reportFilePath, int billNumber)
        {
            if (!_template.Exists)
                throw new FileNotFoundException();

            var reportFile = new FileInfo(reportFilePath);
            reportFile.Delete();

            _template.CopyTo(reportFile.FullName);

            var rows = Products.Select(product => new TableRowContent(new List<FieldContent>
            {
                new FieldContent(_FieldProductId, product.Id.ToString()),
                new FieldContent(_FieldProductPrice, product.Price.ToString()),
                new FieldContent(_FieldProductcategory, product.Category.ToString()),
                new FieldContent(_FieldProductName, product.Name.ToString()),
            })).ToArray();

            var img = File.ReadAllBytes("../ShopSchema/Reports/Template/logo/logo.png");

            var content = new Content(
                new FieldContent(_FieldCompanyName, CompanyName),
                new FieldContent(_FieldDateOfCreation, Date.ToString("dd.MM.yyyy")),
                new FieldContent(_FieldNumberOfBill, billNumber.ToString()),
                new FieldContent(_FieldBuyerName, BuyerName),
                new FieldContent(_FieldCompanyAddres, CompanyAddres),
                new FieldContent(_FieldCompanyName, CompanyName),
                TableContent.Create(_FieldProduct, rows),
                new FieldContent(_FieldBill, Products.Sum(product => product.Price).ToString()),
                new ImageContent(_FieldLogo, img)   //u told that i can use diagram, but i found documentation and there're only tables, text and images https://github.com/UNIT6-open/TemplateEngine.Docx/blob/master/README.md?ysclid=l8ltduhhul163679570
            );

            using (var templateProcessor = new TemplateProcessor(reportFile.FullName).SetRemoveContentControls(true))
            {
                templateProcessor.FillContent(content);
                templateProcessor.SaveChanges();
                reportFile.Refresh();

                return reportFile;
            }
        }

        #endregion
    }
}

