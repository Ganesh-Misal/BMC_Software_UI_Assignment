using BMC_Software_UI_assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class Waits
    {
        public static void implicitWait()
        {
            Config.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
