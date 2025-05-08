using EcommercePlaygroundTests.Extensions;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Components
{
    public class Form<TFormModel> : Component
        where TFormModel : FormModel
    {

        public Form(IWebElement element) : base(element)
        {
        }

        public virtual void AssertFormStructure()
        {
            var expectedFormFields = ((FormModel)Activator.CreateInstance(typeof(TFormModel))).GetFormFields();
            var actualFormGroups = GetFormGroups();

            Assert.That(expectedFormFields.Count, Is.EqualTo(actualFormGroups.Count));

            for (var i = 0; i < actualFormGroups.Count; i++)
            {
                Assert.That(actualFormGroups[i].GetLabel().Text, Is.EqualTo(expectedFormFields[i].Label));
                Assert.That(actualFormGroups[i].IsRequired(), Is.EqualTo(expectedFormFields[i].IsRequired));
                actualFormGroups[i].AssertField(actualFormGroups[i].GetType());
            }
        }

        public virtual void AssertFormStructure<TForm>()
        {
            var expectedFormFields = ((FormModel)Activator.CreateInstance(typeof(TForm))).GetFormFields();
            var actualFormGroups = GetFormGroups();

            Assert.That(expectedFormFields.Count, Is.EqualTo(actualFormGroups.Count));

            for (var i = 0; i < actualFormGroups.Count; i++)
            {
                Assert.That(actualFormGroups[i].GetLabel().Text, Is.EqualTo(expectedFormFields[i].Label));
                Assert.That(actualFormGroups[i].IsRequired(), Is.EqualTo(expectedFormFields[i].IsRequired));
                actualFormGroups[i].AssertField(expectedFormFields[i].ControlType);
            }
        }

        protected virtual List<FormGroup> GetFormGroups()
        {
            return Element.FindElements(By.XPath(".//div[contains(concat(' ',normalize-space(@class),' '),' form-group ') and not(@style=\"display: none ;\")]")).Select(e => e.ToComponent<FormGroup>()).ToList();
        }
    }
}
