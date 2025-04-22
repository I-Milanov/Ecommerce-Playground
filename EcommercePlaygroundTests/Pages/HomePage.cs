using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class HomePage : BaseSection
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=common/home";

        public override string DomTitle => "Your store";
    }
}
