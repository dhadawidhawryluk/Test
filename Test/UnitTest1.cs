using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\d_hawryluk\Desktop\");
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://google.com/");
        }
    }
}