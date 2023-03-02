using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDCSharpProject.Support.Utilities
{
    public class UIUtils
    {
        public void SelectOptionInDropdownByText(IWebElement dropdownElement, string dropdownText)
        {
            SelectElement dropdown = new SelectElement(dropdownElement);
            dropdown.SelectByText(dropdownText);
        }
    }
}
