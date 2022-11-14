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
        
        IWebElement amazonLink => Config.driver.FindElement(By.XPath("(//span[text()='http://www.amazon.in/'])[1]"));
        
        public LoginPageAmazon searchAndPrintResults(string searchtext)
        {
            searchBar.SendKeys(searchtext + Keys.Enter);
            
            //IList<IWebElement> amazonResults = Config.driver.FindElements(By.XPath("//h3[contains(text(), 'Amazon')]"));
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
