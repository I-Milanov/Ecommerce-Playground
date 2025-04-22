using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Sections
{
    public class CartSection : BaseSection
    {
        public CartSection(IWebDriver driver) : base(driver)
        {
        }

        protected override By WrapperLocator { get; set; } = By.XPath("//div[@id='cart-total-drawer']");

        protected IWebElement TotalPrice => Wrapper.GetElementWhenVisible(By.XPath(".//td[text()='Total:']/following-sibling::td"));

        protected IWebElement VatPrice => Wrapper.GetElementWhenVisible(By.XPath(".//td[text()='VAT (20%):']/following-sibling::td"));

        protected IWebElement EcoTax => Wrapper.GetElementWhenVisible(By.XPath(".//td[text()='Eco Tax (-2.00):']/following-sibling::td"));

        protected IWebElement SubTotal => Wrapper.GetElementWhenVisible(By.XPath(".//td[text()='Sub-Total:']/following-sibling::td"));

        protected IWebElement CompareButton => Wrapper.GetElementWhenVisible(By.XPath(".//a[@aria-label='Compare']"));

        protected IWebElement CartButton => Wrapper.GetElementWhenVisible(By.XPath(".//div[@class='cart-icon']"));

        protected IWebElement ProductsTable => Wrapper.GetElementWhenVisible(By.XPath(".//div[contains(@class,'table-responsive')]"));

        protected IWebElement ProductsTableRow(int row) => ProductsTable.GetElementWhenVisible(By.XPath($".//tr[{row}]"));

        protected IWebElement ProductsProduct(int row) => ProductsTableRow(row).GetElementWhenVisible(By.XPath($".//td[2]//a"));

        protected IWebElement ProductsModel(int row) => ProductsTableRow(row).GetElementWhenVisible(By.XPath($".//td[2]//small[1]"));

        protected IWebElement ProductsQuantity(int row) => ProductsTableRow(row).GetElementWhenVisible(By.XPath($".//td[3]"));

        protected IWebElement ProductsPrice(int row) => ProductsTableRow(row).GetElementWhenVisible(By.XPath($".//td[4]"));


        public void AssertCart(params Product[] products)
        {
            Assert.Multiple(() =>
            {
                AssertTotal(products);
                AssertVat(products);
                AssertEcoTax(products);
                AssertSubTotal(products);
                AssertProducts(products);
            });
        }

        protected void AssertTotal(params Product[] products)
        {
            var expectedPrice = products.Select(p => p.Price).Sum();
            var actualPrice = TotalPrice.Text.CurrencyToDecimal();

            Assert.AreEqual(expectedPrice, actualPrice, "Total price is no as expected");
        }

        protected void AssertVat(params Product[] products)
        {
            var expectedvar = (products.Select(p => p.Price).Sum() - GetEcoTax(products)) / 120 * 20;
            var actualVat = VatPrice.Text.CurrencyToDecimal();

            Assert.AreEqual(expectedvar, actualVat, "Vat price is no as expected");
        }

        protected void AssertEcoTax(params Product[] products)
        {
            var expectedvar = GetEcoTax(products);
            var actualVat = EcoTax.Text.CurrencyToDecimal();

            Assert.AreEqual(expectedvar, actualVat, "Eco Tax is no as expected");
        }

        protected void AssertSubTotal(params Product[] products)
        {
            var expectedvar = (products.Select(p => p.Price).Sum() - GetEcoTax(products)) / 120 * 100;
            var actualVat = SubTotal.Text.CurrencyToDecimal();

            Assert.AreEqual(expectedvar, actualVat, "Sub Total is no as expected");
        }

        protected decimal GetEcoTax(params Product[] products)
        {
            return 2.0M * products.Length;
        }

        protected void AssertProducts(params Product[] expectedProducts)
        {
            var actualProducts = GetProducts();

            actualProducts.ShouldBeEquivalentBy(expectedProducts, p => (p.Id, p.Name, p.Price, p.Model));
        }

        protected List<Product> GetProducts()
        {
            var rows = ProductsTable.FindElements(By.XPath(".//tr")).Count;
            var actualProducts = new List<Product>();

            for (int i = 1; i <= rows; i++)
            {
                AddProducts(i, actualProducts);
            }

            return actualProducts;
        }

        protected void AddProducts(int row, List<Product> products)
        {
            var product = new Product();
            product.Id = ProductsProduct(row).ExtractProductIdFromHref();
            product.Name = ProductsProduct(row).Text;
            product.Model = ProductsModel(row).Text.Replace("Model: ", string.Empty);
            
            var quantity = int.Parse(ProductsQuantity(row).Text.Replace("x", string.Empty));

            if (ProductsPrice(row).Text.TryCurrencyToDecimal() is decimal price)
            {
                product.Price = price / quantity;
            }


            for (int i = 0; i < quantity; i++)
            {
                products.Add(product);
            }
        }
    }
}
