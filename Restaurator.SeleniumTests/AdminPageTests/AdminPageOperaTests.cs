using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;

namespace Restaurator.SeleniumTests.AdminPageTests
{
    public class AdminPageOperaTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new OperaDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            IWebElement login = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[2]/input"));
            login.SendKeys("admin@gmail.com");
            IWebElement password = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[3]/input"));
            password.SendKeys("#Admin123");
            IWebElement button = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[5]/button"));
            button.Click();
            webDriver.Navigate().GoToUrl("https://localhost:44371/Admin/User");
        }
        [Test]
        public void SearchInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/label/input"));
            Assert.That(element.Displayed, Is.True);
        }
        public void Select_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("html/body/div/main/div/div[2]/div[1]/label/select"));
            Assert.That(element.Displayed, Is.True);
        }
        public void UserTable_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("html/body/div/main/div/div[2]/table"));
            Assert.That(element.Displayed, Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            if (webDriver != null)
            {
                webDriver.Dispose();
            }
        }

    }
}
