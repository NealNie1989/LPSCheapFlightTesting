using System;
using System.Threading;
using CheapFlights.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CheapFlights.Steps
{
    [Binding]
    public class _002CheapFlightsOneTripSteps
    {
        private IWebDriver driver;
        MainPage mainPage;
        MelDepartingResultPage melDepartingResultPage;

        [BeforeScenario("SearchForTheCheapestFare02")]
        public void StartUp()
        {
            driver = new FirefoxDriver();
            mainPage = new MainPage(driver);
            melDepartingResultPage = new MelDepartingResultPage(driver);
        }

        [AfterScenario("SearchForTheCheapestFare02")]
        public void TearDown()
        {
            driver.Quit();
        }
        [Given(@"I have visited the flight centre")]
        public void GivenIHaveVisitedTheFlightCentre()
        {
            mainPage.Goto();
        }

        [Given(@"I have went the flight centre")]
        public void GivenIHaveWentTheFlightCentre()
        {
            mainPage.Goto();
        }

        [Given(@"I selected trip from Auckland to Melbourne")]
        public void GivenISelectedTripFromAucklandToMelbourne()
        {
            String from = "(AKL) - Auckland Airport - Auckland - New Zealand";
            String to = "(MEL) - Melbourne Airport - Melbourne - Australia";
            mainPage.BookingTicketsForOneTrip(from, to, true);
        }
        
        [Given(@"I selected trip from Melbourne to Auckland")]
        public void GivenISelectedTripFromMelbourneToAuckland()
        {
            String from = "(MEL) - Melbourne Airport - Melbourne - Australia";
            String to = "(AKL) - Auckland Airport - Auckland - New Zealand";
            mainPage.BookingTicketsForOneTrip(from, to, false);
        }
        
        [When(@"I press the first onward select button")]
        public void WhenIPressTheFirstOnwardSelectButton()
        {
            Thread.Sleep(5000);
            mainPage.ChangeToAntherWindowHandle();
            melDepartingResultPage.SelectSortByLowestPrice();
            melDepartingResultPage.SelectDepartingFlight();
        }
        
        [When(@"I press the first backward select button")]
        public void WhenIPressTheFirstBackwardSelectButton()
        {
            Thread.Sleep(5000);
            mainPage.ChangeToAntherWindowHandle();
            melDepartingResultPage.SelectSortByLowestPrice();
            melDepartingResultPage.SelectBackDepartingFlight();
        }
        
        [Then(@"the onward result should be the cheapest")]
        public void ThenTheOnwardResultShouldBeTheCheapest()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")));
            Assert.IsTrue(melDepartingResultPage.IsOnwardLowestPrice().Contains("295"));
        }
        
        [Then(@"the backward result should be the cheapest")]
        public void ThenTheBackwardResultShouldBeTheCheapest()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")));
            Assert.IsTrue(melDepartingResultPage.IsBackwardLowestPrice().Contains("387"));
        }
    }
}
