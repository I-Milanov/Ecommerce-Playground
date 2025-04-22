using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Sections;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EcommercePlaygroundTests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait { get; set; }

        public NavigationSection Navigation => new NavigationSection(Driver);

        public CartSection CartPopUp => new CartSection(Driver);

        protected IJavaScriptExecutor JsExecutor { get; set; }

        public abstract string Url { get; }

        public abstract string DomTitle { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            JsExecutor = (IJavaScriptExecutor)Driver;
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitUntilPageLoaded();
        }

        protected virtual void WaitUntilPageLoaded()
        {
            Driver.WaitUntilReady();
        }
    }
}
