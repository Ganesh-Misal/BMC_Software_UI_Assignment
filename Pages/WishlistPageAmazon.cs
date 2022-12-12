using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMC_Software_UI_assignment.Pages
{
    class WishlistPageAmazon
    {
        public void addToWishlist()
        {
            Config.driver.FindElement(By.Id("wishListMainButton")).Click();
        }

        public void createNewWishlist()
        {
            // add the first product whose rating is 5 out of 5 to the wish list. (Create a new wish list)
            int num = new Random().Next();
            string wishList = "Auto" + num;
            Config.driver.FindElement(By.Id("list-name")).Clear();
            Config.driver.FindElement(By.Id("list-name")).SendKeys(wishList + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Enter);
            Config.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            /*
            IWebElement createListBtn = Config.driver.FindElement(By.XPath("//span[text()='Create List']"));
            //createListBtn.Click();
            */

            Config.driver.FindElement(By.XPath("//a[text()='View Wish List']")).Click();
            Config.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Validate the product is added to the wish list
            Assert.IsTrue(Config.driver.FindElement(By.XPath("//span[text()='" + wishList + "']")).Displayed);
            Assert.IsTrue(Config.driver.FindElement(By.XPath("//a[contains(text(), 'Dell')]/parent::h2 | //a[contains(text(), 'DELL')]/parent::h2")).Displayed);

        }
    }
}
