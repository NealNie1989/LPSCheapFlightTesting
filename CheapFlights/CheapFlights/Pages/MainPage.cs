using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CheapFlights.Pages
{
    public class MainPage
    {
        private IWebDriver driver;
        static String url = "https://www.flightcentre.co.nz/?gclid=Cj0KCQiA8_PfBRC3ARIsAOzJ2uqDS1MWl13d7ZL4R4tukfE19wHT1RIq-mlhq6OadB-BGoSU-TofepMaAhwvEALw_wcB&gclsrc=aw.ds";
        [FindsBy(How = How.Name, Using = "expoint")]
        private IWebElement flyingFrom;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/span[2]/div[1]/div[1]/div[2]")]
        private IWebElement aucklandBtn;

        [FindsBy(How = How.Name, Using = "destination")]
        private IWebElement flyingTo;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/span[2]/div[1]/div[1]/div[2]")]
        private IWebElement melbourneBtn;

        [FindsBy(How = How.Name, Using = "tripType")]
        private IList<IWebElement> tripTypes;

        [FindsBy(How = How.Name, Using = "departDate")]
        private IWebElement departTime;

        [FindsBy(How = How.Name, Using = "arriveDate")]
        private IWebElement returnTime;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/span[2]/div[1]/div[1]/input[1]")]
        private IWebElement departDataForOneTrip;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[5]/button[6]/span[1]")]
        private IWebElement dateChoiceOnward;

        [FindsBy(How = How.XPath, Using = "//button[@type='button']//span[contains(text(),'31')]")]
        private IWebElement dataChoiceBackward;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/span[2]/div[1]/div[1]/input[1]")]
        private IWebElement passengers;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'OK')]")]
        private IWebElement GuestsChoice;

        [FindsBy(How = How.XPath, Using = "//*[@id='mini-panel-fcc_homepage_banner']/div[2]/div/div/div/div/div/div/div[2]/div[4]/button/div/div")]
        private IWebElement submitBtn;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void Goto()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void BookingTicketsForOneTrip(String from, String to, Boolean departTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("expoint")));

            tripTypes.ElementAt(1).Click();

            flyingFrom.Click();
            flyingFrom.Clear();
            flyingFrom.SendKeys(from);
            aucklandBtn.Click();

            
            flyingTo.Click();
            flyingTo.Clear();
            flyingTo.SendKeys(to);
            melbourneBtn.Click();

            departDataForOneTrip.Clear();
            departDataForOneTrip.Click();
            Thread.Sleep(5000);
            
            if (departTime)
            {
                dateChoiceOnward.Click();
            }
            else
            {
                dataChoiceBackward.Click();
            }

            Thread.Sleep(5000);
            passengers.Click();
            Thread.Sleep(5000);
            GuestsChoice.Click();

            Thread.Sleep(5000);
            submitBtn.Click();
        }

        public void BookingTicketsForRoundTrip()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("expoint")));

            tripTypes.ElementAt(0).Click();

            flyingFrom.Click();
            flyingFrom.Clear();
            flyingFrom.SendKeys("(AKL) - Auckland Airport - Auckland - New Zealand");
            aucklandBtn.Click();

            
            flyingTo.Click();
            flyingTo.Clear();
            flyingTo.SendKeys("(MEL) - Melbourne Airport - Melbourne - Australia");
            melbourneBtn.Click();

            departTime.Click();
            Thread.Sleep(5000);
            dateChoiceOnward.Click();
            Thread.Sleep(5000);


           // returnTime.Click();
           // Thread.Sleep(5000);
            dataChoiceBackward.Click();

            Thread.Sleep(5000);
            passengers.Click();
            Thread.Sleep(5000);
            GuestsChoice.Click();

            Thread.Sleep(5000);
            submitBtn.Click();
        }

        public void ChangeToAntherWindowHandle()
        {
            String existingWindowHandle1 = driver.CurrentWindowHandle;

            string popupHandle = string.Empty;
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle1)
                {
                    popupHandle = handle; break;
                }
            }

            driver.SwitchTo().Window(popupHandle);

        }

        public void ChangeBackWindowHandle(String existingWindowHandle)
        {
            driver.Close();
            driver.SwitchTo().Window(existingWindowHandle);

        }

    }
}
