using EcommercePlaygroundTests.Models.FormModels;
using EcommercePlaygroundTests.Services.ConfigurationService;

namespace EcommercePlaygroundTests.Tests
{
    public class RegistrationFormTests : BaseTests
    {
        [Test]
        public void AssertRegistrationForm_When_OpenRegistrationPage()
        {
            var setting = ConfigurationService.GetConfiguration();

            RegistrationPage.Open();

            RegistrationPage.Form.AssertFormStructure<RegisterFormModel>();
        }
    }
}