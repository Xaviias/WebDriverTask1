using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTask;
using System;

namespace Tests
{
    public class PastebinTests
    {
        private IWebDriver _driver;
        private PastebinHomePage _pastebinHomePage;
        private string code;
        private string title;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _pastebinHomePage = new PastebinHomePage(_driver);
            code = "Hello from WebDriver";
            title = "helloweb";
        }

        [Test]
        public void CreateNewPasteTest()
        {
            _pastebinHomePage.NavigateToPage();
            _pastebinHomePage.EnterPasteCode(code);
            _pastebinHomePage.SelectPasteExpiration();
            _pastebinHomePage.EnterPasteName(title);
            _pastebinHomePage.CreateNewPaste();

            Assert.IsTrue(_driver.Title.Contains(title));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}