using BMC_Software_UI_assignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BMC_Software_UI_assignment
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Config.driver = new ChromeDriver();
            Config.driver.Navigate().GoToUrl(Config.googleUrl);
            Config.driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchAndLoginToAmazon()
        {
            

            GoogleSearch gs = new GoogleSearch();
            gs.searchAndPrintResults("amazon");

            LoginPageAmazon lpa = new LoginPageAmazon();
            lpa.signIn("0123@gmail.com", "0123");

            bool helloText = Config.driver.FindElement(By.Id("nav-link-accountList-nav-line-1")).Displayed;

            
        }


        [Test]
        public void SearchProduct()
        {
            HomePageAmazon hpa = new HomePageAmazon();
            hpa.searchElectronicsProduct("dell computers");
            hpa.applyPriceFilter("20000", "30000");

        }

        [TearDown]
        public void Cleanup()
        {
            Config.driver.Close();
        }
    }
}