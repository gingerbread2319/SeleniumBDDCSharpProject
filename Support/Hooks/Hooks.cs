using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using BoDi;
using SeleniumBDDCSharpProject.Support.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using Newtonsoft.Json;

namespace SeleniumBDDCSharpProject.Support.Hooks
{
    [Binding]
    public sealed class Hooks :ExtentReport
    {
        private readonly IObjectContainer _container;
        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string propertiesPath = dir.Replace("bin\\Debug\\net6.0\\", "Configurations\\config.properties");

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            var properties = ConfigUtils.ReadProperties(propertiesPath);

            IWebDriver driver = BrowserUtils.DriverManager(properties["browser"]);
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeaturew(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                if (stepType.ToLower() == "given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType.ToLower() == "when")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType.ToLower() == "then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }

            if (scenarioContext.TestError != null)
            {
                if (stepType.ToLower() == "given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType.ToLower() == "when")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message); ;
                }
                else if (stepType.ToLower() == "then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message); ;
                }
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTeardown();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}