using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.ServicesPage
{
    public class ServicesPageHeaderFragment : AbstractFragment
    {
        private static By PageHeaderText = By.CssSelector("h1");

        [FindsBy(How = How.CssSelector, Using = ".page-header")]
        private IWebElement _servicesPageHeaderFragment;

        protected override void InitializeFragment()
        {
            SetRootElement(_servicesPageHeaderFragment);
        }

        internal TextObject GetPageHeaderText() => GetChildElement<TextObject>(PageHeaderText);
    }
}