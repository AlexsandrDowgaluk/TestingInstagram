using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestingInstagram.StepsUI
{
    [Binding]
    public class TestingUISteps {


      
        private IWebDriver _driver;
        public TestingUISteps(IWebDriver driver)
    {

        _driver = driver;
    }
    
        [Given(@"navigate to application")]
        public void GivenNavigateToApplication()
        {

            

           
            _driver.Navigate().GoToUrl("http://localhost:8080/test6/employee");
            ;

        }

        [Given(@"enter username id and password")]
        public void GivenEnterUsernameIdAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _driver.FindElement(By.Name("name")).SendKeys((String)data.name);
            _driver.FindElement(By.Id("id")).SendKeys("4");
            _driver.FindElement(By.Name("contactNumber")).SendKeys("0939517619");
            Thread.Sleep(2000);
        }
        
        [Given(@"click login")]
        public void GivenClickLogin()
        {
            _driver.FindElement(By.XPath("/html/body/form/button")).Click();
        }
        
        [Then(@"should see user logger to the application")]
        public void ThenShouldSeeUserLoggerToTheApplication()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/h2[contains(text(),'User successfully registered')]"));
            Assert.Multiple(() =>
            {
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
               // Assert.That(element.Text, Is.Null, "Header text not found !!!");
            });

        }
    }
}
