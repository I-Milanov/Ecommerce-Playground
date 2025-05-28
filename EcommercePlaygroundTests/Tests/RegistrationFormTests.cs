using EcommercePlaygroundTests.Models.FormModels;
using EcommercePlaygroundTests.Services.ConfigurationService;

namespace EcommercePlaygroundTests.Tests
{
    public class RegistrationFormTests : BaseTests
    {
           [Test]
        public void AssertRegistrationForm_When_OpenRegistrationPage()
        {
            var setting = ConfigurationService.GetConfiguration().Language;

            string homePageText = Strings.Loans;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bg");
            homePageText = Strings.HomePage;
            var test = Strings.Loans;
            RegistrationPage.Open();

            RegistrationPage.Form.AssertFormStructure<RegisterFormModel>();
        }
    }
}