using FluentAssertions;
using Ninject;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Utils;

namespace ClassLibrary1.StepDefs
{
    [Binding]
    public sealed class WorkPageStepDef
    {
        [Inject]
        private IWorkPage _workPage = WebDriverFactory.ninjectKernel.Get<IWorkPage>();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        private ScenarioContext _scenarioContext;

        public WorkPageStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"Check the work page is opened")]
        public void ThenCheckTheWorkPageIsOpened()
        {
            _workPage.WaitForComplete();
            _workPage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be(UIConfigurationSettings.ValtechWorkUrl,
                "Valtech services page should be opened");
        }

        [Then(@"the work page header name should be ""(.*)""")]
        public void ThenTheServicesPageHeaderNameShouldBe(string pageName)
        {
            _workPage.WaitForComplete();
            _workPage.Check();
            _workPage.GetWorkPageHeaderTitle().Should().Be(pageName,
                        $"The page title is {_workPage.GetWorkPageHeaderTitle()}");
        }
    }
}