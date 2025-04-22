using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EcommercePlaygroundTests.Extensions
{
    public static class WebElementExtensions
    {
        public static IWebElement ScrollTo(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;

            IJavaScriptExecutor JsExecutor = (IJavaScriptExecutor)driver;

            JsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);

            return element;
        }

        public static IWebElement HoverTo(this IWebElement element)
        {
            ScrollTo(element);

            var driver = ((IWrapsDriver)element).WrappedDriver;
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            return element;
        }
    }
}
