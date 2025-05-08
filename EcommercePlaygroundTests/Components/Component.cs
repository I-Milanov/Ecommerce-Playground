using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public abstract class Component
    {
        protected Component(IWebElement element)
        {
            Element = element;
        }

        protected IWebElement Element { get; set; }
    }
}
