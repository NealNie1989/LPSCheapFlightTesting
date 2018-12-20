using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CheapFlights.Pages
{
    class TimeOutPage
    {
        private IWebDriver driver;


        public TimeOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public Boolean TimeOutInfo()
        {
            return driver.FindElement(By.XPath("/html[1]/body[1]/div[10]/div[1]/div[1]/p[1]")).Displayed;
        }
    }
}
