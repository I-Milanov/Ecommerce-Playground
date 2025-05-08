using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public class EmailInput : TextInput
    {
        public EmailInput(IWebElement element) : base(element)
        {
        }

        public bool IsValidEmail()
        {
            var value = GetText();
            return value.Contains("@") && value.Contains(".");
        }
    }
}
