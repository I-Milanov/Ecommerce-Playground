using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class ComparePage : BasePage
    {
        public ComparePage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=product/compare";

        public override string DomTitle => "Product Comparsion";

        protected IWebElement Table => Driver.GetElementWhenVisible(By.XPath($"//div[@id='content']//table"));

        protected IWebElement Colspan => Table.FindElement(By.XPath($".//td[@colspan]"));

        protected IWebElement TableCell(string rowName, int column) => Table.FindElement(By.XPath($".//td[text()='{rowName}']/following-sibling::td[{column}]"));

        protected IWebElement ProductCell(int column) => TableCell("Product", column);
        protected IWebElement ProductCellLink(int column) => ProductCell(column).FindElement(By.XPath(".//a"));

        protected IWebElement ImageCell(int column) => TableCell("Image", column).FindElement(By.XPath(".//*[name()='img']"));

        protected IWebElement PriceCell(int column) => TableCell("Price", column);
        protected IWebElement ModelCell(int column) => TableCell("Model", column);
        protected IWebElement BrandCell(int column) => TableCell("Brand", column);
        protected IWebElement AvailabilityCell(int column) => TableCell("Availability", column);
        protected IWebElement RatingCell(int column) => TableCell("Rating", column);
        protected IWebElement SummaryCell(int column) => TableCell("Summary", column);
        protected IWebElement WeightCell(int column) => TableCell("Weight", column);
        protected IWebElement DimensionsCell(int column) => TableCell("Dimensions (L x W x H)", column);

        public void AssertProducts(params Product[] expectedProducts)
        {
            var actualProducts = GetProducts();

            // Use if you wish to assert custom properties
            //actualProducts.ShouldBeEquivalentBy(expectedProducts, p => (p.Id, p.Name, p.Price));

            CollectionAssert.AreEquivalent(expectedProducts, actualProducts);
        }

        protected Product[] GetProducts()
        {
            int colspan;
            int.TryParse(Colspan.GetAttribute("colspan"), out colspan);
            int productsCount = colspan - 1;

            var products = new Product[productsCount];

            for (int i = 0; i < productsCount; i++)
            {
                var product = GetProduct(i + 1);

                products[i] = product;
            }

            return products;
        }

        protected Product GetProduct(int column)
        {
            var product = new Product();
            product.Name = ProductCell(column).Text;
            product.Id = ProductCellLink(column).ExtractProductIdFromHref();

            product.CompareImage = ImageCell(column).GetAttribute("src");

            if (PriceCell(column).Text.TryCurrencyToDecimal() is decimal price)
            {
                product.Price = price;
            }

            product.Model = ModelCell(column).Text;
            product.Brand = BrandCell(column).Text;
            product.Availability = AvailabilityCell(column).Text;
            product.Summary = RatingCell(column).Text;
            product.Summary = SummaryCell(column).Text;
            product.Weight = WeightCell(column).Text;
            product.Dimensions = DimensionsCell(column).Text;

            return product;
        }
    }
}
