using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public class FormGroup : Component
    {
        public FormGroup(IWebElement element) : base(element)
        {
        }

        public IWebElement GetLabel()
        {
            var elementLabel = Element.FindElement(By.XPath(".//label"));

            return elementLabel;
        }

        public bool IsRequired()
        {
            var elementLabel = Element.GetAttribute("class");

            return elementLabel.Contains("required");
        }

        public void AssertField(Type type)
        {
            IWebElement element = null;

            if (type == typeof(TextInput))
            {
               element = Element.FindElements(By.XPath(".//input")).FirstOrDefault();
            }

            if (type == typeof(PasswordInput))
            {
                element = Element.FindElements(By.XPath(".//input[@type='password']")).FirstOrDefault();
            }

            if (type == typeof(EmailInput))
            {
                element = Element.FindElements(By.XPath(".//input[@type='text']")).FirstOrDefault();
            }

            if (type == typeof(RadioInput))
            {
                element = Element.FindElements(By.XPath(".//input[@type='radio']")).FirstOrDefault();
            }

            Assert.That(element, Is.Not.Null, "Form field is not found");
           
            if (type == typeof(RadioInput))
            {
                return;
            }

            Assert.That(element.Displayed, Is.True, "Form field is not visible");

        }
    }
}
