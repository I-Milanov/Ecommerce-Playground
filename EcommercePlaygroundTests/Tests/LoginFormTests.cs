using EcommercePlaygroundTests.Models.FormModels;

namespace EcommercePlaygroundTests.Tests
{
    public class LoginFormTests : BaseTests
    {
        [Test]
        public void AssertLoginForm_When_OpenLoginPage()
        {
            LoginPage.Open();

            LoginPage.Form.AssertFormStructure<LoginFormModel>();
        }
    }
}