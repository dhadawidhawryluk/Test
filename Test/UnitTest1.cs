
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        public DesiredCapabilities capability = new DesiredCapabilities();

        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver(@"C:\Users\d_hawryluk\Desktop");
            driver = new RemoteWebDriver(
                new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            capability.SetCapability("browserstack.user", "sgn4");
            capability.SetCapability("browserstack.key", "A9TsFdoHRRnRq7iaGPP5");

        }

        [Test]
        public void Test1()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("C:\\Users\\d_hawryluk\\source\\repos\\Test\\Test\\appsettings.json");
            var connectionStringConfig = builder.Build();
            capability.SetCapability("browser", connectionStringConfig.GetSection("browser").Value);
            capability.SetCapability("browser_version", connectionStringConfig.GetSection("browser_version").Value);
            capability.SetCapability("os", connectionStringConfig.GetSection("os").Value);
            driver.Navigate().GoToUrl("https://google.com");
            driver.FindElement(By.Name("q")).SendKeys("BrowserStack");
        }
    }
}