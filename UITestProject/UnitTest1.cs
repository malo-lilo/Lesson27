using System;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITestProject
{

    public class Tests
    {
        private WebDriver driver;
        private WebDriverWait wait;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        


        [Test]
        public void AutorizationTesting()
        {
            Auth();
            Assert.AreEqual("https://crm.supermamki.ru/index.php?action=profile", driver.Url, 
                "Вы не перешли на страницу личного кабинета");
        }

        public void Auth()
        {
            driver.Navigate().GoToUrl("https://crm.supermamki.ru/");
            driver.Manage().Window.Maximize();
            var authorization = driver.FindElement(By.XPath("//*[@id='signin_link']"));
            authorization.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement inputUsername = wait.Until(e => e.FindElement(By.XPath("//*[@id='username']")));
            inputUsername.SendKeys("UITestung");
            var inputPassword = driver.FindElement(By.Name("password"));
            inputPassword.SendKeys("123456789qwer");
            driver.FindElement(By.CssSelector("#authForm > div:nth-child(3) > div > button")).Click();
            
        }
        
        [Test]
        public void RegistrationTesting()
        {
            Utils.UserRegistration(driver, wait);
            Assert.AreEqual("https://crm.supermamki.ru/index.php?action=zakups", driver.Url, 
                "Вы не перешли на страницу совместных закупок");
        }
    }
}