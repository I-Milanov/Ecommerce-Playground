using EcommercePlaygroundTests.Models.FormModels;

namespace EcommercePlaygroundTests.Tests
{
    public class RegistrationFormTests : BaseTests
    {
        [Test]
        public void AssertRegistrationForm_When_OpenRegistrationPage()
        {
            RegistrationPage.Open();

            RegistrationPage.Form.AssertFormStructure<RegisterFormModel>();
        }
    }
}