
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\d_hawryluk\Desktop");
        }

        [Test]
        public void Test1()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("C:\\Users\\d_hawryluk\\source\\repos\\Test\\Test\\appsettings.json");
            var connectionStringConfig = builder.Build();
            driver.Navigate().GoToUrl("https://google.com");
            driver.FindElement(By.Name("q")).SendKeys(connectionStringConfig.GetSection("Data").Value);
        }
    }
}