using System;
using System.Collections.Generic;
using System.Text;

namespace BMC_Software_UI_assignment.Utilities
{
    class Utilities
    {
        public void wait()
        {
            Config.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
