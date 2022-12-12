using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMC_Software_UI_assignment.Pages
{
    class LoginPageAmazon
    {
        IWebElement btnSignIn_1 => Config.driver.FindElement(By.XPath("//span[text()='Sign in']/ancestor::div[@id='nav-signin-tooltip']"));
        IWebElement textEmail => Config.driver.FindElement(By.Id("ap_email"));
        IWebElement btnContinue => Config.driver.FindElement(By.Id("continue"));
        IWebElement textPassword => Config.driver.FindElement(By.Id("ap_password"));
        IWebElement btnSignIn_2 => Config.driver.FindElement(By.Id("signInSubmit"));


        //login to https://www.amazon.in/
        public HomePageAmazon signIn(string username, string password)
        {
            btnSignIn_1.Click();
            textEmail.SendKeys(username);
            btnContinue.Click();
            textPassword.SendKeys(password);
            btnSignIn_2.Click();
            return new HomePageAmazon();

        }
    }
}
