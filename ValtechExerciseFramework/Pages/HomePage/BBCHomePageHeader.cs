using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.HomePage
{
    public class BBCHomePageHeader : AbstractFragment
    {
        private static By NewsLink = By.CssSelector("#orb-nav-links > ul > li.orb-nav-news > a");
        private static By SportsLink = By.CssSelector("#orb-nav-links > ul > li.orb-nav-sport > a");
        private static By WeatherLink = By.CssSelector("#orb-nav-links > ul > li.orb-nav-weather > a");

        [FindsBy(How = How.CssSelector, Using = "#orb-header")]
        private IWebElement _BBCHompageHeaderRoot;

        protected override void InitializeFragment()
        {
            SetRootElement(_BBCHompageHeaderRoot);
        }

        internal Button GetNewsLink() => GetChildElement<Button>(NewsLink);
        internal Button GetSportsLink() => GetChildElement<Button>(SportsLink);
        internal Button GetWeatherLink() => GetChildElement<Button>(WeatherLink);
    }
}