using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EcommercePlaygroundTests.Extensions
{
    public static class WebDriverExtensions
    {
        private const int DefaultTimeoutInSeconds = 10;

        public static void WaitForUserInteraction(this IWebDriver driver, int time = 2000)
        {
            Thread.Sleep(time);
        }

        public static IWebElement GetElementWhenExist(this IWebDriver driver, By by)
        {
            var wait = CreateWait(driver);

            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static IWebElement GetElementWhenVisible(this IWebDriver driver, By by)
        {
            var wait = CreateWait(driver);

            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitUntilReady(this IWebDriver driver)
        {
            var wait = CreateWait(driver);
            var jsExecutor = (IJavaScriptExecutor)driver;

            wait.Until(d => {
                var readyState = jsExecutor.ExecuteScript("return document.readyState").ToString();
                return readyState == "complete";
            });
        }

        private static WebDriverWait CreateWait(IWebDriver driver)
        {
           return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
        }
    }
}
