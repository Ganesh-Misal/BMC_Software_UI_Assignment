using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BMC_Software_UI_assignment.Pages
{
    class GoogleSearch
    {
        IWebElement searchBar => Config.driver.FindElement(By.Name("q"));
        IWebElement amazonLink => Config.driver.FindElement(By.XPath("//h3[text()='Amazon.in']"));

        // print all the search results & Click on the link which takes you to the amazon login page.
        public LoginPageAmazon searchAndPrintResults(string searchtext)
        {
            searchBar.SendKeys(searchtext + Keys.Enter);

            IList<IWebElement> amazonResults = Config.driver.FindElements(By.TagName("h3"));
            foreach (var link in amazonResults)
            {
                string linkText = link.Text;
                Console.WriteLine(linkText);
            }

            Config.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            amazonLink.Click();
            return new LoginPageAmazon();
        }

    }
}
