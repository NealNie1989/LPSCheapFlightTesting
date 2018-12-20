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
    class MelDepartingResultPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[1]/div[3]/div[2]/div[1]/select[1]")]
        private IWebElement sortSelect;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[1]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")]
        private IWebElement lowestPriceSelect;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[1]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")]
        private IWebElement lowestBackPrice;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[2]/div[3]/div[2]/div[1]/select[1]")]
        private IWebElement sortSelectForR;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[2]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")]
        private IWebElement lowestDepartFlightForRTrip;

        public SelectElement SortSelect
        {
            get { return new SelectElement(sortSelect); }
        }

        public SelectElement SortSelectForR
        {
            get { return new SelectElement(sortSelectForR); }
        }

        public MelDepartingResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void SelectSortByLowestPrice()
        {
            WebDriverWait wait = new WebDriverWait(driver,new TimeSpan(0,0,30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[1]/div[3]/div[2]/div[1]/select[1]")));

            SortSelect.SelectByText("Lowest Price");

        }
        public void SelectDepartingFlight()
        {
            
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='outboundFlights']/div[4]/div/div[1]/div[2]/div[5]/div[2]/button")));

                lowestPriceSelect.Click();        
            
        }

        public void SelectBackDepartingFlight()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[1]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")));

            lowestBackPrice.Click();

        }

        public void SelectSortWayForRTrip()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[2]/div[3]/div[2]/div[1]/select[1]")));

            SortSelectForR.SelectByText("Lowest Price");
        }

        public void SelectDepartFlightForRTrip()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[2]/div[4]/div[1]/div[1]/div[2]/div[5]/div[2]/button[1]")));

            lowestDepartFlightForRTrip.Click();
        }

        public String IsLowestPrice()
        {
            return driver.FindElement(By.XPath("//select[@class='sort-by']")).Text;
        }

        public String IsOnwardLowestPrice()
        {
            return driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")).Text;
        }

        public String IsBackwardLowestPrice()
        {
            return driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")).Text;
        }

        public Boolean IsExistAfterThreeSecond()
        {
            return driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/form[1]/section[2]/div[3]/div[2]/div[1]/label[1]")).Displayed;
        }
    }
}


