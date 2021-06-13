using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;

namespace Restaurator.SeleniumTests.RegisterPageTests
{
    public class RegisterPageOperaTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new OperaDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Register");
        }
        [Test]
        public void UserNameInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[1]/div/input"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void FirstNameInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[2]/div[1]/div/input"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void LastNameInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[2]/div[2]/div/input"));
            Assert.That(element.Displayed, Is.True);
        }
        [Test]
        public void EmailInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[3]/div/input"));
            Assert.That(element.Displayed, Is.True);
        }
        public void PasswordInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[4]/div/input"));
            Assert.That(element.Displayed, Is.True);
        }
        public void ConfirmPasswordInput_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[5]/div[1]/input"));
            Assert.That(element.Displayed, Is.True);
        }
        public void SignOnButton_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[1]/div[5]/div[2]/button"));
            Assert.That(element.Displayed, Is.True);
        }
        public void FacebookSignOnButton_Displayed_IsTrue()
        {
            IWebElement element = webDriver.FindElement(By.XPath("/html/body/div/main/div/div/div/div/div/form[2]/div/div/button"));
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
