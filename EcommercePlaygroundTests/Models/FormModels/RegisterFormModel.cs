using EcommercePlaygroundTests.Components;

namespace EcommercePlaygroundTests.Models.FormModels
{
    public class RegisterFormModel : FormModel
    {
        [Label("First Name")]
        [Required]
        [ComponentType(typeof(TextInput))]
        public string FirstName { get; set; }

        [Label("Last Name")]
        [Required]
        [ComponentType(typeof(TextInput))]
        public string LastName { get; set; }

        [Label("E-Mail")]
        [Required]
        [ComponentType(typeof(TextInput))]
        public string Email { get; set; }

        [Label("Telephone")]
        [Required]
        [ComponentType(typeof(TextInput))]
        public string Telephone { get; set; }

        [Label("Password")]
        [Required]
        [ComponentType(typeof(PasswordInput))]
        public string Password { get; set; }

        [Label("Password Confirm")]
        [Required]
        [ComponentType(typeof(PasswordInput))]
        public string PasswordConfirm { get; set; }

        [Label("Subscribe")]
        [ComponentType(typeof(RadioInput))]
        public string Subscribe { get; set; }
    }
}
