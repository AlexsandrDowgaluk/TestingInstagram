using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TestingInstagram
{
    [Binding]
    public class WrongPasswordSteps
    {
        private IWebDriver _driver;
        public WrongPasswordSteps(IWebDriver driver)
        {

            _driver = driver;
        }
        [Given(@"I is on registration page")]
        public void GivenIIsOnRegistrationPage()
        {
            _driver.Navigate().GoToUrl("https://www.instagram.com");
            Thread.Sleep(2000);
        }
        
        [When(@"I enters following credention")]
        public void WhenIEntersFollowingCredention()
        {
            _driver.FindElement(By.Name("emailOrPhone")).SendKeys("0939517619");
            _driver.FindElement(By.Name("username")).SendKeys("alexanderdowgaluk");
            _driver.FindElement(By.Name("password")).SendKeys("san4es");
            Thread.Sleep(2000);
        }
        
        [When(@"User click button registration")]
        public void WhenUserClickButtonRegistration()
        {
            _driver.FindElement(By.XPath("/html/body/span/section/main/article/div[2]/div[1]/div/form/div[7]/div/button")).Click();
            Thread.Sleep(2000);

        }

        [Then(@"Alert error message")]
        public void ThenAlertErrorMessage()
        {
            //var element = _driver.FindElement(By.XPath("/*[@id='ssfErrorAlert'][contains(@class, 'Ma93n') and normalize-space(text() = 'Це ім'я вже використовується. Спробуйте інше.')]"));
            var element = _driver.FindElement(By.XPath("/html/body/span/section/main/article/div[2]/div[1]/div/form/div[8]/p[contains(text(),'Це ім'я вже використовується. Спробуйте інше.')]"));
            //var element = _driver.FindElement(By.XPath("//*[@id='ssfErrorAlert']/p[contains(text(),'Це ім'я вже використовується. Спробуйте інше.')]"));
            Assert.Multiple(() =>
            {
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
                //Assert.That(element.Text, Is.Null, "Header text not found !!!");
            });
        }
    }
}
