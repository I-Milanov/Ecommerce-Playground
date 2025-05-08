using EcommercePlaygroundTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EcommercePlaygroundTests.Tests
{
    public class BaseTests
    {
        public IWebDriver Driver { get; set; }

        public HomePage HomePage => new HomePage(Driver);

        public SearchPage SearchPage => new SearchPage(Driver);

        public ComparePage ComparePage => new ComparePage(Driver);

        public LoginPage LoginPage => new LoginPage(Driver);

        public RegistrationPage RegistrationPage => new RegistrationPage(Driver);

        public virtual ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return options;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = GetChromeOptions();

            Driver = new ChromeDriver(options);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
