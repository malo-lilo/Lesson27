using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITestProject;

public class Utils
{
    public static void UserRegistration(WebDriver driver, WebDriverWait wait)
    {
        driver.Navigate().GoToUrl("https://crm.supermamki.ru/");
        var registration = driver.FindElement(By.XPath("//*[@id='reg_link']"));
        //Assert.IsTrue(registration.Displayed);
        registration.Click();
        Random rnd = new Random();
        IWebElement inputUsername = wait.Until(e => e.FindElement(By.Name("username")));
        inputUsername.SendKeys(rnd.NextInt64(1111111,99999999) + "uitest");
        var inputEmail = driver.FindElement(By.Name("email"));
        inputEmail.SendKeys(rnd.NextInt64(1111111,99999999) + "@gmail.com");
        var inputPassword = driver.FindElement(By.Name("password"));
        inputPassword.SendKeys("123456789qwer");
        var inputPasswordConfirm = driver.FindElement(By.Name("password_confirm"));
        inputPasswordConfirm.SendKeys("123456789qwer");
        var checkbox = driver.FindElement(By.CssSelector("#registerForm > div.checkbox > label > input[type = checkbox]"));
        //Assert.IsTrue(checkbox.Selected);
        checkbox.Click();
        var inputControlQuestion = driver.FindElement(By.Name("qa_answer"));
        inputControlQuestion.SendKeys("5");
        driver.FindElement(By.CssSelector("#registerForm > div:nth-child(10) > div > button")).Click();
        }

  
}