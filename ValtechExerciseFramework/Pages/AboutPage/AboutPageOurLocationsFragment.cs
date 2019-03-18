using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.AboutPage
{
    public class AboutPageOurLocationsFragment : AbstractFragment
    {
        private static By OurOfficesLink = By.CssSelector(".investors__our-locations a");

        [FindsBy(How = How.CssSelector, Using = "#container")]
        private IWebElement _aboutPageOurLocationsFragment;

        protected override void InitializeFragment()
        {
            SetRootElement(_aboutPageOurLocationsFragment);
        }

        internal ClickableObject GetOurOfficesLink() => GetChildElement<ClickableObject>(OurOfficesLink);
    }
}