using BoDi;
using TechTalk.SpecFlow;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.StepDefs.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();

        public static object FoldersPathelper { get; private set; }

        public WebDriverHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [Before]
        public void InitializeWebDriver() =>
            _objectContainer.RegisterInstanceAs(WebDriverFactory.InitDriver());

        [After]
        public void ClearCookies() => _webDriverUtils.DeleteCookies();

        [After]
        public void TearDown() => WebDriverFactory.CloseBrowser();
    }
}