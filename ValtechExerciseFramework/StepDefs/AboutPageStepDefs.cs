using FluentAssertions;
using Ninject;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Utils;

namespace ClassLibrary1.StepDefs
{
    [Binding]
    public sealed class AboutPageStepDefs
    {
        [Inject]
        private IAboutPage _aboutPage = WebDriverFactory.ninjectKernel.Get<IAboutPage>();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        private ScenarioContext _scenarioContext;

        public AboutPageStepDefs(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"Check the about page is opened")]
        public void ThenCheckTheAboutPageIsOpened()
        {
            _aboutPage.WaitForComplete();
            _aboutPage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be(UIConfigurationSettings.valtechAboutUrl,
                "Valtech about page should be opened");
        }

        [Then(@"the about page header name should be ""(.*)""")]
        public void ThenTheAboutPageHeaderNameShouldBe(string pageName)
        {
            _aboutPage.WaitForComplete();
            _aboutPage.Check();
            _aboutPage.GetAboutPageHeaderTitle().Should().Be(pageName,
                $"The page title is {_aboutPage.GetAboutPageHeaderTitle()}");
        }

        [When(@"I click on on 'Our offices' link")]
        public void WhenIClickOnOnLink() =>
            _aboutPage.ClickOurOfficesLink();


        [Then(@"Check the contact page is opened")]
        public void ThenCheckTheContactPageIsOpened()
        {
            _aboutPage.WaitForComplete();
            _aboutPage.Check();
            _aboutPage.GetCurrentUrl().Should().Be(UIConfigurationSettings.ValtechContactUsUrl,
                    $"The page title is {_aboutPage.GetCurrentUrl()}");
        }

        [Then(@"Get the number of offices")]
        public void ThenGetTheNumberOfOffices() =>
            System.Console.WriteLine(_aboutPage.GetCountOfOfficelocations());
    }
}