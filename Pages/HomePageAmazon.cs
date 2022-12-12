using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReadingExcelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Utilities;

namespace BMC_Software_UI_assignment.Pages
{
    class HomePageAmazon
    {
        SelectElement selectElectronics = new SelectElement(Config.driver.FindElement(By.Id("searchDropdownBox")));
        IWebElement searchItem => Config.driver.FindElement(By.Id("twotabsearchtextbox"));
        IWebElement textMinPrice => Config.driver.FindElement(By.Id("low-price"));
        IWebElement textMaxPrice => Config.driver.FindElement(By.Id("high-price"));
        IWebElement btnGo => Config.driver.FindElement(By.ClassName("a-button-input"));

        // Lists for storing products, prices & ratings
        IList<IWebElement> pricesListPage1 => Config.driver.FindElements(By.ClassName("a-price-whole"));
        IList<IWebElement> pricesListPage2 => Config.driver.FindElements(By.ClassName("a-price-whole"));
        IList<IWebElement> productsListPage1 => Config.driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));
        IList<IWebElement> productsListPage2 => Config.driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));
        IList<IWebElement> ratingsListPage1 => Config.driver.FindElements(By.XPath("//span[@class='a-size-base']/ancestor::span[@aria-label]"));
        IList<IWebElement> ratingsListPage2 => Config.driver.FindElements(By.XPath("//span[@class='a-size-base']/ancestor::span[@aria-label]"));

        // Elements for page navigation (TODO: Pagination to yet to be implemented)
        IWebElement page2 => Config.driver.FindElement(By.XPath("//a[@aria-label='Go to page 2']"));
        IWebElement page1 => Config.driver.FindElement(By.XPath("//a[@aria-label='Go to page 1']"));

        int sr;

        Actions actions = new Actions(Config.driver);

        // search for dell computers
        public void searchElectronicsProduct(string productName)
        {
            selectElectronics.SelectByValue("search-alias=electronics");
            searchItem.SendKeys(productName + Keys.Enter);

        }

        // apply the filter of range Rs 20000 to 30000
        public void applyPriceFilter(string minPrice, string maxPrice)
        {
            textMinPrice.SendKeys(minPrice);
            textMaxPrice.SendKeys(maxPrice);
            btnGo.Click();
        }

        // Validate all the products on the first 2 pages are shown in the range of Rs 30000 to 50000
        public void validatePriceAndPrintProduct()
        {
            /* TODO: Combined lists to be implemented for products, prices & ratings.
            IList<IWebElement> finalProductList = (IList<IWebElement>)productsListPage1.Concat(productsListPage2);
            IList<IWebElement> finalPriceList = (IList<IWebElement>)pricesListPage1.Concat(pricesListPage2);
            IList<IWebElement> finalPriceList = (IList<IWebElement>)pricesListPage1.Concat(pricesListPage2);
            */

            //page2.Click();
            actions.MoveToElement(page2).Build().Perform();
            Utilities.Waits.implicitWait();

            Console.WriteLine("Products list on Page 1:");
            for (int i = 0; i < productsListPage1.Count; i++)
            {
                sr = i;
                if (int.Parse(pricesListPage1[i].Text.Remove(2, 1)) >= int.Parse($"minPriceValue: {ReadExcelData.ReadData(1, "minPriceValue") }") && int.Parse(pricesListPage1[i].Text.Remove(2, 1)) <= int.Parse($"maxPriceValue: {ReadExcelData.ReadData(1, "maxPriceValue") }"))
                {
                    Console.WriteLine((sr + 1) + ". Product - {0}, Price - {1}", productsListPage1[i].Text, pricesListPage1[i].Text);
                    //Assert.GreaterOrEqual(pricesListPage1[i].Text, $"minPriceValue: {ReadExcelData.ReadData(1, "minPriceValue") }");
                    //Assert.LessOrEqual(pricesListPage1[i].Text, $"maxPriceValue: {ReadExcelData.ReadData(1, "maxPriceValue") }");
                }
                else
                {
                    Console.WriteLine("Outside filter range: " + (sr + 1) + ". Product - {0}, Price - {1}", productsListPage1[i].Text, pricesListPage1[i].Text);
                }

            }

            Console.WriteLine("Products list on Page 2:");
            for (int i = 0; i < productsListPage2.Count; i++)
            {
                sr = i;
                if (int.Parse(pricesListPage2[i].Text.Remove(2, 1)) >= 20000 && int.Parse(pricesListPage2[i].Text.Remove(2, 1)) <= 30000)
                {

                    Console.WriteLine((sr + 1) + ". Product - {0}, Price - {1}", productsListPage2[i].Text, pricesListPage2[i].Text);
                    //Assert.GreaterOrEqual(pricesListPage2[i].Text, $"minPriceValue: {ReadExcelData.ReadData(1, "minPriceValue") }");
                    //Assert.LessOrEqual(pricesListPage2[i].Text, $"maxPriceValue: {ReadExcelData.ReadData(1, "maxPriceValue") }");

                }
                else
                {

                    Console.WriteLine("Outside filter range: " + (sr + 1) + ". Product - {0}, Price - {1}", productsListPage2[i].Text, pricesListPage2[i].Text);
                }

            }


        }

        //print all the products on the first 2 pages whose rating is 5 out of 5
        public void print5StarProducts()
        {
            Console.WriteLine("List of 5 star products on Page 1:");
            for (int i = 0; i < ratingsListPage1.Count; i++)
            {
                sr = i;
                if (ratingsListPage1[i].Text.Contains("5.0"))
                {

                    Console.WriteLine((sr + 1) + ". Product - {0}, Price - {1} & Rating - {2} ", productsListPage1[i].Text, pricesListPage1[i].Text, ratingsListPage1[i].Text);
                }

            }

            Console.WriteLine("List of 5 star products on Page 2:");
            for (int i = 0; i < ratingsListPage2.Count; i++)
            {
                sr = i;
                if (ratingsListPage2[i].Text.Contains("5.0"))
                {

                    Console.WriteLine((sr + 1) + ". Product - {0}, Price - {1} & Rating - {2}", productsListPage2[i].Text, pricesListPage2[i].Text, ratingsListPage2[i].Text);
                }

            }
        }

        public WishlistPageAmazon select5StarProduct()
        {
            /*
            IList<IWebElement> finalRatingList = (IList<IWebElement>)ratingsListPage1.Concat(ratingsListPage2);
            IList<IWebElement> finalProductList = (IList<IWebElement>)productsListPage1.Concat(productsListPage2);
            */
            actions.MoveToElement(page1).Build().Perform();
            Utilities.Waits.implicitWait();

            for (int i = 0; i < ratingsListPage1.Count; i++)
            {

                if (ratingsListPage1[i].Text.Contains("5.0"))
                {
                    productsListPage1[i].Click();
                    break;
                }

            }

            List<string> handles = new List<string>();
            handles = Config.driver.WindowHandles.ToList();
            Config.driver.SwitchTo().Window(handles[1]);

            return new WishlistPageAmazon();
        }

    }
}
