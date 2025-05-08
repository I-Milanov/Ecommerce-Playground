using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public class TextInput : Component, IComponentText
    {
        public TextInput(IWebElement element) : base(element)
        {
        }

        public void SetText(string email)
        {
            Element.Clear();
            Element.SendKeys(email);
        }

        public string GetText()
        {
            return Element.GetAttribute("value");
        }

        public void Clear()
        {
            Element.Clear();
        }

        public bool IsDisplayed => Element.Displayed;
    }
}
