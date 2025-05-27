using Microsoft.Extensions.Configuration;

namespace EcommercePlaygroundTests.Services.ConfigurationService;

public sealed class ConfigurationService
{
    private static IConfigurationRoot _root;

    static ConfigurationService()
    {
        _root = InitializeConfiguration();
    }

    public static AppSettings GetConfiguration() => _root.Get<AppSettings>();

    private static IConfigurationRoot InitializeConfiguration()
    {
        return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
    }
}

