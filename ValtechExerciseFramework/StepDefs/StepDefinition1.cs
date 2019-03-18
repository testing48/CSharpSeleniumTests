using FluentAssertions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.StepDefs
{
    [Binding]
    public sealed class StepDefinition1
    {
        [Inject]
        private IHomePage _homePage = WebDriverFactory.ninjectKernel.Get<IHomePage>();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        private ScenarioContext _scenarioContext;

        public StepDefinition1(ScenarioContext scenarioContext) =>
            _scenarioContext = scenarioContext;
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I open the BBC Homepage")]
        public void GivenIOpenTheBBCHomepage()
        {
            _webDriverUtils.Navigate("https://www.bbc.co.uk/");
        }

        [Then(@"the homepage is displayed")]
        public void ThenTheHomepageIsDisplayed()
        {
            _homePage.WaitForComplete();
            _homePage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be("https://www.bbc.co.uk/",
                "BBC Homepage should be opened");
        }

        [When(@"I click the sports link")]
        public void WhenIClickTheSportsLink()
        {
            _homePage.ClickSportsLink();
        }


        [Then(@"the sports page is displayed")]
        public void ThenTheSportsPageIsDisplayed()
        {

            _homePage.WaitForComplete();
            _homePage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be("https://www.bbc.co.uk/sport",
                "BBC Homepage should be opened");
        }
    }
}
