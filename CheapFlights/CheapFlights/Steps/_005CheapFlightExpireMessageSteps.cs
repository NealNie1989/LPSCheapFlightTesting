using System;
using System.Threading;
using CheapFlights.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CheapFlights.Steps
{
    [Binding]
    public class _005CheapFlightExpireMessageSteps
    {
        private IWebDriver driver;
        MainPage mainPage;
        MelDepartingResultPage melDepartingResultPage;
        TimeOutPage timeOutPage;
        [BeforeScenario("SearchForTheCheapestFare05")]
        public void StartUp()
        {
            driver = new FirefoxDriver();
            mainPage = new MainPage(driver);
            melDepartingResultPage = new MelDepartingResultPage(driver);
            timeOutPage = new TimeOutPage(driver);
        }
        [AfterScenario("SearchForTheCheapestFare05")]
        public void TearDown()
        {
            driver.Quit();
        }
        [Given(@"I have visited the home page")]
        public void GivenIHaveVisitedTheHomePage()
        {
            mainPage.Goto();
        }
        
        [Given(@"I have selected info")]
        public void GivenIHaveSelectedInfo()
        {
            mainPage.BookingTicketsForRoundTrip();
        }
        
        [When(@"I wait until it expired")]
        public void WhenIWaitUntilItExpired()
        {
            Thread.Sleep(1800000);
            mainPage.ChangeToAntherWindowHandle();
        }
        
        [Then(@"the porper message should be on the screen")]
        public void ThenThePorperMessageShouldBeOnTheScreen()
        { 
            Assert.IsTrue(timeOutPage.TimeOutInfo());
        }
    }
}
