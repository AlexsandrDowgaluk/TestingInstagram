using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestingInstagram.StepsUI
{
    [Binding]
    public class LoginToAccountSteps
    {


        private IWebDriver _driver;
        public LoginToAccountSteps (IWebDriver driver)
        {

            _driver = driver;
        }
        [Given(@"I is on Login Page")]
        public void GivenIIsOnLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.instagram.com");
            Thread.Sleep(2000);
        }
        
        [When(@"I enter following creadentids")]
        public void WhenIEnterFollowingCreadentids()
        {
            

            _driver.FindElement(By.Name("emailOrPhone")).SendKeys("0939517619");
            _driver.FindElement(By.Name("username")).SendKeys("alexanderdowgaluk");
            _driver.FindElement(By.Name("password")).SendKeys("san4es24061988");
            Thread.Sleep(2000);
        }
        
        [When(@"I click button registration")]
        public void WhenIClickButtonRegistration()
        {
           _driver.FindElement(By.XPath("/html/body/span/section/main/article/div[2]/div[1]/div/form/div[7]/div/button")).Click();
            Thread.Sleep(2000);
            
           
        }
        
        [Then(@"The profile page will open")]
        public void ThenTheProfilePageWillOpen()
        {
            
            var element = _driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[2][contains(@class, 'aOOlW   HoLwm ') and normalize-space(text() = 'Не зараз')]"));
            Assert.Multiple(() =>
            {
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
                //Assert.That(element.Text, Is.Null, "Header text not found !!!");
            });
        }
    }
}
