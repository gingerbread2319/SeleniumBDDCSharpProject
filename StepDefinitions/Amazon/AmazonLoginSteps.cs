using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;

namespace SeleniumBDDCSharpProject.StepDefinitions
{
    [Binding]
    public class AmazonLoginSteps
    {
        private IWebDriver driver;

        public AmazonLoginSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [StepDefinition(@"the user login to amazon valid credentials")]
        public void WhenTheUserLoginToAmazonValidCredentials()
        {
            driver.FindElement(By.Id("signInSubmit")).Click();
        }

        [StepDefinition(@"click the Sign-in button in the pop-up")]
        public void WhenClickTheSign_InButtonInThePop_Up()
        {
            driver.FindElement(By.XPath("//*[@id='nav-signin-tooltip']/a[@data-nav-role='signin']")).Click();
        }

        [StepDefinition(@"the user enters '(.*)' in the email field")]
        public void WhenTheUserEntersInTheEmailField(string email)
        {
            driver.FindElement(By.Id("ap_email")).SendKeys(email);
        }

        [StepDefinition(@"click the Continue button")]
        public void WhenClickTheContinueButton()
        {
            driver.FindElement(By.Id("continue")).Click();
        }

        [StepDefinition(@"the user enters '(.*)' in the password field")]
        public void WhenTheUserEntersInThePasswordField(string password)
        {
            driver.FindElement(By.Id("ap_password")).SendKeys(password);
        }

        [StepDefinition(@"click the Sign-in button")]
        public void WhenClickTheSign_InButton()
        {
            driver.FindElement(By.Id("signInSubmit")).Click();
        }

        [StepDefinition(@"the user should be redirected to amazon dashboard")]
        public void ThenTheUserShouldBeRedirectedToAmazonDashboard()
        {
            string greetings = driver.FindElement(By.Id("nav-link-accountList-nav-line-1")).Text;
            greetings.Should().NotContain("sign in");
        }

        [StepDefinition(@"the alert message '(.*)' should be visible")]
        public void ThenTheAlertMessageShouldBeVisible(string message)
        {
            string alertmessage = driver.FindElement(By.XPath("//div[@class='a-alert-content']/descendant::*[@class='a-list-item']")).Text;
            alertmessage.Should().Contain(message);
        }
    }
}
