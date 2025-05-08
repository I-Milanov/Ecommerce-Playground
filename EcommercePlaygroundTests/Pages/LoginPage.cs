using EcommercePlaygroundTests.Components;
using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models.FormModels;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=account/login";

        public override string DomTitle => "Account Login";

        public Form<LoginFormModel> Form => Driver.FindElement(By.XPath($"//h2/following-sibling::form")).ToComponent<Form<LoginFormModel>>();

    }
}
