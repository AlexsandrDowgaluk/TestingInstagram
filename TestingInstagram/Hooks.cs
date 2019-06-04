using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using DotLiquid;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestingInstagram
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        
        public Hooks(IObjectContainer objectContainer)
        {
            
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
           
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\User\source\repos\TestingInstagram\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();

        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.StackTrace).Log(Status.Fail,"Mylog");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message).Log(Status.Fail, "Mylog");

                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message).Log(Status.Fail, "Mylog");

            }


           
        }
        [Before]
        public void Scen()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [BeforeScenario("mytag","login", "wrongPassword")]
        public void Initialize()
        {
            
            var path = System.IO.Path.GetFullPath(@"C:\Users\User\source\repos\TestingInstagram\packages\Selenium.WebDriver.GeckoDriver.0.24.0\driver\win64");
            FirefoxDriverService servise = FirefoxDriverService.CreateDefaultService(path, "geckodriver.exe");
            _driver = new FirefoxDriver(servise);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
           

        }
        [AfterScenario("mytag", "login", "wrongPassword")]
        public void CleanUp()
        {

            
        }
    }
}

