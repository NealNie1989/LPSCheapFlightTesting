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
    public class _001CheapFlightsSortDecendSteps
    {
        private IWebDriver driver;
        MainPage mainPage;
        MelDepartingResultPage melDepartingResultPage;
        MelReturningResultPage melReturningResultPage;

        [BeforeScenario("SearchForTheCheapestFare01")]
        public void StartUp()
        {
            driver = new FirefoxDriver();
            mainPage = new MainPage(driver);
            melDepartingResultPage = new MelDepartingResultPage(driver);
            melReturningResultPage = new MelReturningResultPage(driver);
        }

        [AfterScenario("SearchForTheCheapestFare01")]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I have visit the Flight Centre Page")]
        public void GivenIHaveVisitTheFlightCentrePage()
        {
            mainPage.Goto();
        }
        
        [Given(@"I have choose one flight")]
        public void GivenIHaveChooseOneFlight()
        {
            String from = "(AKL) - Auckland Airport - Auckland - New Zealand";
            String to = "(MEL) - Melbourne Airport - Melbourne - Australia";
            mainPage.BookingTicketsForOneTrip(from,to,true);
        }
        
        [When(@"I press the Lowest price on drop list")]
        public void WhenIPressTheLowestPriceOnDropList()
        {
            Thread.Sleep(5000);
            mainPage.ChangeToAntherWindowHandle();
            melDepartingResultPage.SelectSortByLowestPrice();
        }
        
        [Then(@"the result should be show on the screen")]
        public void ThenTheResultShouldBeShowOnTheScreen()
        {
            Assert.IsTrue(melDepartingResultPage.IsLowestPrice().Contains("Lowest Price"));
        }
    }
}
