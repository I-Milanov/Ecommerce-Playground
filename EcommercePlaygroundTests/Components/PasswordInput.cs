using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public class PasswordInput : TextInput
    {
        public PasswordInput(IWebElement element) : base(element)
        {
        }
    }
}
