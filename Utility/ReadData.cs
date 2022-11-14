using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BMC_Software_UI_assignment.Utility
{
    class ReadData
    {
        public static Hashtable DataReader(string fileName)
        {
            var path = TestContext.CurrentContext.TestDirectory;
            path = Path.Combine(path, fileName);
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Hashtable ht = JsonConvert.DeserializeObject<Hashtable>(json);
                return ht;
            }
        }
        //public static DataReaderUsage()
        //{
        //    Hashtable inputData = DataReader("Data.json");
        //    IWebElement username = Config.driver.FindElement(By.Id("emailInput"));
        //    IWebElement password = Config.driver.FindElement(By.Id("passwordInput"));
        //    username.SendKeys(Convert.ToString(inputData["username"]));
        //    password.SendKeys(Convert.ToString(inputData["password"]));
        //}
    }
}
