using EcommercePlaygroundTests.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EcommercePlaygroundTests.Extensions
{
    public static class WebElementExtensions
    {
        public static TComponent ToComponent<TComponent>(this IWebElement element)
            where TComponent : Component
        {          
            return (TComponent)Activator.CreateInstance(typeof(TComponent), element);
        }

        public static IWebElement ScrollTo(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            IJavaScriptExecutor JsExecutor = (IJavaScriptExecutor)driver;
            JsExecutor.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);

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

        public static int ExtractProductIdFromHref(this IWebElement element)
        {
            var href = element.GetAttribute("href");
            var queryParams = href.Split("?").Last().Split("&");
            var productIdParam = queryParams.First(p => p.StartsWith("product_id"));

            return int.Parse(productIdParam.Replace("product_id=", string.Empty));
        }

        public static IWebElement GetElementWhenVisible(this IWebElement element, By by, int timeoutInSeconds = 10)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(_ =>
            {
                try
                {
                    var child = element.FindElement(by);
                    return child.Displayed ? child : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
    }
}
