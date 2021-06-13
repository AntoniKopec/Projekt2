using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Restaurator.SeleniumTests.LoginPageTests
{
    public class LoginPageMicrosoftEdgeTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new EdgeDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
        }
        [Test]
        public void EmailInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[2]/input"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void PasswordInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[3]/input"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void LoginButton_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[1]/div[5]/button"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void FacebookLoginButton_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/section/form[2]/div/p/button"));
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
