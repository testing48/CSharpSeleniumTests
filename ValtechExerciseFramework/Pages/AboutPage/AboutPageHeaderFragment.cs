using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.AboutPage
{
    public class AboutPageHeaderFragment : AbstractFragment
    {
        private static By PageHeaderText = By.CssSelector("h1");

        [FindsBy(How = How.CssSelector, Using = ".page-header")]
        private IWebElement _aboutPageHeaderFragmentRoot;

        protected override void InitializeFragment()
        {
            SetRootElement(_aboutPageHeaderFragmentRoot);
        }

        internal TextObject GetPageHeaderText() => GetChildElement<TextObject>(PageHeaderText);
    }
}