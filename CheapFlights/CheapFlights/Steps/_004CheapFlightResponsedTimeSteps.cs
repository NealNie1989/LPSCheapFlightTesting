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
    public class _004CheapFlightResponsedTimeSteps
    {
        private IWebDriver driver;
        MainPage mainPage;
        MelDepartingResultPage melDepartingResultPage;
        [BeforeScenario("SearchForTheCheapestFare04")]
        public void StartUp()
        {
            driver = new FirefoxDriver();
            mainPage = new MainPage(driver);
            melDepartingResultPage = new MelDepartingResultPage(driver);
        }

        [AfterScenario("SearchForTheCheapestFare04")]
        public void TearDown()
        {
            driver.Quit();
        }
        [Given(@"I have visited the main page")]
        public void GivenIHaveVisitedTheMainPage()
        {
            mainPage.Goto();
        }
        
        [Given(@"I have submited the information")]
        public void GivenIHaveSubmitedTheInformation()
        {
            mainPage.BookingTicketsForRoundTrip();
        }
        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            Thread.Sleep(3500);
            mainPage.ChangeToAntherWindowHandle();
        }
        
        [Then(@"the response time should be less than (.*)")]
        public void ThenTheResponseTimeShouldBeLessThan(Decimal p0)
        {
            Assert.IsTrue(melDepartingResultPage.IsExistAfterThreeSecond());
        }
    }
}
