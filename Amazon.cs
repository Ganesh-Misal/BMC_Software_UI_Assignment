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
            ReadExcelData.PopulateInCollection(@"C:\Users\Ganesh\source\repos\BMC Software UI assignment\Data\Amazon_Data.xlsx");
        }

        [Test]
        public void SearchAndLoginToAmazon()
        {
            // Search 'amazon' on google
            GoogleSearch gs = new GoogleSearch();
            gs.searchAndPrintResults($"searchString: {ReadExcelData.ReadData(1, "searchString") }");

            // Login to Amazon
            LoginPageAmazon lpa = new LoginPageAmazon();
            lpa.signIn($"username: {ReadExcelData.ReadData(1, "username") }", $"password: {ReadExcelData.ReadData(1, "password") }");

            bool helloText = Config.driver.FindElement(By.Id("nav-link-accountList-nav-line-1")).Displayed;
            Assert.IsTrue(helloText);

            // Searching product on Amazon Homepage
            HomePageAmazon hpa = new HomePageAmazon();
            hpa.searchElectronicsProduct($"searchProductString: {ReadExcelData.ReadData(1, "searchProductString") }");
            hpa.applyPriceFilter($"minPriceValue: {ReadExcelData.ReadData(1, "minPriceValue") }", $"maxPriceValue: {ReadExcelData.ReadData(1, "maxPriceValue") }");
            hpa.validatePriceAndPrintProduct();
            hpa.print5StarProducts();
            hpa.select5StarProduct();

            //Adding product to wishlist
            WishlistPageAmazon wlp = new WishlistPageAmazon();
            wlp.addToWishlist();
            wlp.createNewWishlist();
        }

        [TearDown]
        public void Cleanup()
        {
            Config.driver.Quit();
        }
    }
}