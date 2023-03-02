using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions.Common;

namespace SeleniumBDDCSharpProject.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver driver;

        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [StepDefinition(@"the user navigates to '(.*)'")]
        public void GivenTheUserNavigatesToURL(string url)
        {
            driver.Url = url;
        }
    }
}