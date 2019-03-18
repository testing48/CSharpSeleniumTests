using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.HomePages
{
    public class HomePageAcceptCookies : AbstractFragment
    {
        private static By AcceptCookiesButton = By.CssSelector(".cookie__action a");

        [FindsBy(How = How.CssSelector, Using = ".startpage #cookiebanner")]
        private IWebElement _homePageAcceptCookies;

        protected override void InitializeFragment()
        {
            SetRootElement(_homePageAcceptCookies);
        }

        internal Button GetAcceptCookiesButton() => GetChildElement<Button>(AcceptCookiesButton);
    }
}