using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMC_Software_UI_assignment.Pages
{
    class HomePageAmazon
    {
        IWebElement btnAll => Config.driver.FindElement(By.Id("searchDropdownBox"));
        IWebElement optionElectronics => Config.driver.FindElement(By.XPath("//option[text()='Electronics']"));

        IWebElement searchItem => Config.driver.FindElement(By.Id("/twotabsearchtextbox"));

        IWebElement textMinPrice => Config.driver.FindElement(By.Id("low-price"));

        IWebElement textMaxPrice => Config.driver.FindElement(By.Id("high-price"));

        IWebElement btnGo => Config.driver.FindElement(By.ClassName("a-button-input"));

        public void searchElectronicsProduct(string productName)
        {
            btnAll.Click();

            optionElectronics.Click();

            searchItem.SendKeys(productName + Keys.Enter);

        }

        public void applyPriceFilter(string minPrice, string maxPrice)
        {
            textMinPrice.SendKeys(minPrice);
            textMaxPrice.SendKeys(maxPrice);
            btnGo.Click();
        }
    }
}
