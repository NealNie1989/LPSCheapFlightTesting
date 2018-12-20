using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CheapFlights.Pages
{
    class MelReturningResultPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[3]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")]
        private IWebElement lowestReturnSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='availability']/section/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]")]
        private IWebElement totalPrice;

        public MelReturningResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void SelectReturningFlight()
        {
            
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[3]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")));

                lowestReturnSelect.Click();         
        }

        public String IsTotalFare()
        {
            return driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")).Text;
        }

       
    }
}
