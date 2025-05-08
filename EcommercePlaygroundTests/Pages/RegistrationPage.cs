using EcommercePlaygroundTests.Components;
using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using EcommercePlaygroundTests.Models.FormModels;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=account/register";

        public override string DomTitle => "Registered Account";

        public Form<RegisterFormModel> Form => Driver.GetElementWhenVisible(By.XPath($"//h1/following-sibling::form")).ToComponent<Form<RegisterFormModel>>();
    }
}
