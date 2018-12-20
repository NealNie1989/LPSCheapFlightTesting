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
    public class _003CheapFlightRoundTripSteps
    {
        private IWebDriver driver;
        MainPage mainPage;
        MelDepartingResultPage melDepartingResultPage;
        MelReturningResultPage melReturningResultPage;

        [BeforeScenario("SearchForTheCheapestFare03")]
        public void StartUp()
        {
            driver = new FirefoxDriver();
            mainPage = new MainPage(driver);
            melDepartingResultPage = new MelDepartingResultPage(driver);
            melReturningResultPage = new MelReturningResultPage(driver);
         }

        [AfterScenario("SearchForTheCheapestFare03")]
        public void TearDown()
        {
            driver.Quit();
        }
        [Given(@"I have visited the flight centre page")]
        public void GivenIHaveVisitedTheFlightCentrePage()
        {
            mainPage.Goto();
        }
        
        [Given(@"I have select the round trip from Auckland to Melbourne")]
        public void GivenIHaveSelectTheRoundTripFromAucklandToMelbourne()
        {
            mainPage.BookingTicketsForRoundTrip();
        }
        
        [When(@"I selected the depart flight and arrive flight")]
        public void WhenISelectedTheDepartFlightAndArriveFlight()
        {
            Thread.Sleep(5000);
            mainPage.ChangeToAntherWindowHandle();
            melDepartingResultPage.SelectSortWayForRTrip();
            melDepartingResultPage.SelectDepartFlightForRTrip();
            melReturningResultPage.SelectReturningFlight();

        }
        
        [Then(@"the result should be calculator correctly")]
        public void ThenTheResultShouldBeCalculatorCorrectly()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[3]/div[3]/div[1]/div[1]/div[1]/section[1]/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/span[2]")));

            Assert.IsTrue(melReturningResultPage.IsTotalFare().Contains("668"));
        }
    }
}
