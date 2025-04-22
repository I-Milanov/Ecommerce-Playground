using EcommercePlaygroundTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EcommercePlaygroundTests.Sections
{
    public abstract class BaseSection
    {
        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected IJavaScriptExecutor JsExecutor { get; set; }

        public BaseSection(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            JsExecutor = (IJavaScriptExecutor)Driver;
        }

        protected abstract By WrapperLocator { get; set; }

        protected IWebElement Wrapper => Driver.GetElementWhenVisible(WrapperLocator);
    }
}
