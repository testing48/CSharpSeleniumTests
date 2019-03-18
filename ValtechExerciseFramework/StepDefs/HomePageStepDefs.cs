using FluentAssertions;
using Ninject;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Utils;

namespace ClassLibrary1.StepDefs
{
    [Binding]
    public sealed class HomePageStepDefs
    {
        [Inject]
        private IHomePage _homePage = WebDriverFactory.ninjectKernel.Get<IHomePage>();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        private ScenarioContext _scenarioContext;

        public HomePageStepDefs(ScenarioContext scenarioContext) =>
            _scenarioContext = scenarioContext;

        [Given("I open the homepage")]
        public void IOpenTheHomePage() =>
            _webDriverUtils.Navigate("https://www.bbc.co.uk/");

        [Then(@"Check the homepage is opened")]
        public void ThenCheckTheHomePageIsOpened()
        {
            _homePage.WaitForComplete();
            _homePage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be("https://www.bbc.co.uk/",
                "BBC Homepage should be opened");
        }

        [When(@"I accept cookies")]
        public void WhenIAcceptCookies() =>
            _homePage.ClickSportsLink();


        [Then(@"I confirm blog title is ""(.*)""")]
        public void ThenIConfirmBlogTitleIs(string blogTitle)
        {
            _homePage.WaitForComplete();
            _homePage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be("https://www.bbc.co.uk/sport/",
                "BBC Homepage should be opened");
        }

        [When(@"I click on the ""(.*)"" blog")]
        public void WhenIClickOnTheBlog(string number)
        {
            _homePage.ClickOnBlog(number.ToLower());
        }

        [Then(@"Check page title is ""(.*)""")]
        public void ThenCheckPageTitleIs(string pageTitle)
        {
            _homePage.WaitForComplete();
            _homePage.Check();
            _webDriverUtils.GetTitle()
               .Should().Be(pageTitle,
                $"The page title is { _webDriverUtils.GetTitle()}");
        }

        [When(@"I click top navigation ""(.*)"" link")]
        public void ThenIClickTopNagivationLink(string linkName) =>
            _homePage.ClickTopNavigationBarLink(linkName);
    }
}
