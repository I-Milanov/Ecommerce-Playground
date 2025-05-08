using EcommercePlaygroundTests.Components;

namespace EcommercePlaygroundTests.Models.FormModels
{
    public class LoginFormModel : FormModel
    {
        [Label("E-Mail Address")]
        [ComponentType(typeof(EmailInput))]
        public string EmailAddress { get; set; }

        [Label("Password")]
        [ComponentType(typeof(PasswordInput))]
        public string Password { get; set; }
    }
}
