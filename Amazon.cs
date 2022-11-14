using BMC_Software_UI_assignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReadingExcelData;

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

            ReadExcelData.PopulateInCollection(@"C:\Users\Ganesh\source\repos\BMC Software UI assignment\Data\Amazon_Data.xlsx");

            GoogleSearch gs = new GoogleSearch();
            gs.searchAndPrintResults($"searchString: {ReadExcelData.ReadData(1, "searchString") }");

            LoginPageAmazon lpa = new LoginPageAmazon();
            lpa.signIn($"username: {ReadExcelData.ReadData(1, "username") }", $"password: {ReadExcelData.ReadData(1, "password") }");

            bool helloText = Config.driver.FindElement(By.Id("nav-link-accountList-nav-line-1")).Displayed;

            
        }


        [Test]
        public void SearchProduct()
        {
            HomePageAmazon hpa = new HomePageAmazon();
            hpa.searchElectronicsProduct($"searchProductString: {ReadExcelData.ReadData(1, "searchProductString") }");
            hpa.applyPriceFilter($"minPriceValue: {ReadExcelData.ReadData(1, "minPriceValue") }", $"maxPriceValue: {ReadExcelData.ReadData(1, "maxPriceValue") }");

        }

        [TearDown]
        public void Cleanup()
        {
            Config.driver.Close();
        }
    }
}