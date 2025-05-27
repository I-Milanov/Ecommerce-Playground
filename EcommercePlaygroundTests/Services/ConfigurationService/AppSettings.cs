using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Services.ConfigurationService
{
    public class AppSettings
    {
        public string Language { get; set; }

        public string Browser { get; set; }

        public Timeout Timeout { get; set; }

        public Browser GetBrowser => Enum.Parse<Browser>(Browser, true);

    }

    public class Timeout
    {
        public long ElementToExist { get; set; }
        public long PageToLoad { get; set; }

    }
}
