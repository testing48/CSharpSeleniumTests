using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.WorkPage
{
    public class WorkPageHeaderFragment : AbstractFragment
    {
        private static By PageHeaderText = By.CssSelector("h1");

        [FindsBy(How = How.CssSelector, Using = ".page-header")]
        private IWebElement _workPageHeaderFragmentRoot;

        protected override void InitializeFragment()
        {
            SetRootElement(_workPageHeaderFragmentRoot);
        }

        internal TextObject GetPageHeaderText() => GetChildElement<TextObject>(PageHeaderText);
    }
}