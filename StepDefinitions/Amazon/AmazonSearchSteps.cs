using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBDDCSharpProject.Support.Utilities;
using System.Globalization;

namespace SeleniumBDDCSharpProject.StepDefinitions.Amazon
{
    [Binding]
    public class AmazonSearchSteps
    {

        private IWebDriver driver;
        UIUtils UI = new UIUtils();

        public AmazonSearchSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [StepDefinition(@"the user clicks the Search-in dropdown")]
        public void WhenTheUserClicksTheSearch_InDropdown()
        {
            driver.FindElement(By.Id("nav-search-dropdown-card")).Click();
        }

        [StepDefinition(@"I select '(.*)' option in Search-in dropdown")]
        public void WhenISelectOptionInSearch_InDropdown(string searchOption)
        {
            IWebElement dropdownElement = driver.FindElement(By.Id("searchDropdownBox"));
            UI.SelectOptionInDropdownByText(dropdownElement, searchOption);
        }

        [When(@"I enter '(.*)' in the Search bar")]
        public void WhenIEnterInTheSearchBar(string keyword)
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(keyword);
        }


        [StepDefinition(@"I click the Search button")]
        public void WhenIClickTheSearchButton()
        {
            driver.FindElement(By.XPath("//*[@id='nav-search-submit-text']/parent::div")).Click();
        }

        [StepDefinition(@"I verify that the search result in the page is exactly (.*) items")]
        public void ThenIVerifyThatTheSearchResultInThePageIsExactlyItems(int numberOfItems)
        {
            int searchItemNum = driver.FindElements(By.XPath("//div[starts-with(@cel_widget_id,'MAIN-SEARCH_RESULTS')]")).Count();
            searchItemNum.Should().Be(numberOfItems);
        }

        [StepDefinition(@"I select '(.*)' option in Sort By dropdown")]
        public void WhenISelectOptionInSortByDropdown(string sortingOption)
        {
            IWebElement dropdownElement = driver.FindElement(By.XPath("//select[@id='s-result-sort-select']"));
            UI.SelectOptionInDropdownByText(dropdownElement, sortingOption);
            Thread.Sleep(2000);
        }

        [StepDefinition(@"I verify that the pagination bar is displayed")]
        public void ThenIVerifyThatThePaginationBarIsDisplayed()
        {
            driver.FindElement(By.XPath("//span[@class='s-pagination-strip']")).Displayed.Should().BeTrue();
        }

        [StepDefinition(@"I verify that the search result is sorted by publication date")]
        public void ThenIVerifyThatTheSearchResultIsSortedByPublicationDate()
        {
            IList<IWebElement> publicationDateElements = driver.FindElements(By.XPath("//div[starts-with(@cel_widget_id,'MAIN-SEARCH_RESULTS')]/descendant::span[@class='a-size-base a-color-secondary a-text-normal']"));
            
            int count = 0;
            string publicationDate1 = "";
            string publicationDate2 = "";

            foreach (IWebElement publicationDateElement in publicationDateElements)
            {   
                DateTime date1;
                DateTime date2;
                Console.WriteLine("DATE1: " + publicationDate1);

                if (count == 0)
                {
                    publicationDate1 = publicationDateElement.Text;
                    Console.WriteLine("DATE1: " + publicationDate1);
                    count++;
                    continue;
                } else if (count > 0)
                {
                    publicationDate2 = publicationDateElement.Text;
                    Console.WriteLine("DATE2: " + publicationDate2);
                }

                date1 = DateTime.ParseExact(publicationDate1, "MMM d, yyyy", null);
                date2 = DateTime.ParseExact(publicationDate2, "MMM d, yyyy", null);
                date1.Should().BeOnOrAfter(date2);

                publicationDate1 = publicationDate2;
            }
        }
    }
}
