using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.CommonFragments
{
    public class MainHeaderFragment : AbstractFragment
    {
        private static By HeaderNavigationMenuLinks = By.CssSelector("#navigationMenuWrapper ul li a");

        [FindsBy(How = How.CssSelector, Using = ".header__wrapper")]
        private IWebElement _mainHeaderFragmentRoot;

        protected override void InitializeFragment()
        {
            SetRootElement(_mainHeaderFragmentRoot);
        }

        internal ClickableObject GetHeaderNavigationMenuLinks(string linkName) => GetChildElements<ClickableObject>(HeaderNavigationMenuLinks)
            .Find(x => x.Text.ToLower()
            .Contains(linkName.ToLower()));
    }
}