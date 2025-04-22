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
            WaitUntilReady();
        }

        protected virtual void WaitUntilReady()
        {
            Wait.Until(d => {
                var readyState = JsExecutor.ExecuteScript("return document.readyState").ToString();
                return readyState == "complete";
            });
        }
    }
}
