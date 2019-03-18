using FluentAssertions;
using Ninject;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Utils;

namespace ClassLibrary1.StepDefs
{
    [Binding]
    public sealed class ServicesPageStepDef
    {
        [Inject]
        private IServicesPage _servicesPage = WebDriverFactory.ninjectKernel.Get<IServicesPage>();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        private ScenarioContext _scenarioContext;

        public ServicesPageStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"Check the services page is opened")]
        public void ThenCheckTheServicesPageIsOpened()
        {
            _servicesPage.WaitForComplete();
            _servicesPage.Check();
            _webDriverUtils.GetCurrentUrl().Should()
                .Be(UIConfigurationSettings.valtechServicesUrl,
                "Valtech services page should be opened");
        }

        [Then(@"the services page header name should be ""(.*)""")]
        public void ThenTheServicesPageHeaderNameShouldBe(string pageName)
        {
            _servicesPage.WaitForComplete();
            _servicesPage.Check();
            _servicesPage.GetServicesPageHeaderTitle().Should().Be(pageName,
                    $"The page title is {_servicesPage.GetServicesPageHeaderTitle()}");
        }
    }
}