// /Utilities/ConfigReader.cs
using Microsoft.Extensions.Configuration;
using SITS_Test_Automation.Tests.UITest.Interfaces;
using System.IO;

public class ConfigReader : IConfigReader
{
    private readonly IConfigurationRoot _configuration;

    public ConfigReader()
    {
        // Build configuration from appsettings.json
        var path = @"C:\Users\dirav1\OneDrive - Inter IKEA Group\Documents\new\SITS_Test_Automation\Configurations\appsettings.json";
        var build = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path, optional: false, reloadOnChange: true);
        _configuration = build.Build();

    }

    public string GetApplicationUrl()
    {
        return _configuration["ApplicationUrl"];
    }

    public string GetUserEmail()
    {
        return _configuration["UserEmail"];
    }

    public string GetUsername()
    {
        return _configuration["Username"];
    }

    public string GetPassword()
    {
        return _configuration["Password"];
    }

    public string GetBaseURL()
    {
        return _configuration["baseURL"];
    }
}
