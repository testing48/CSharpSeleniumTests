using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.HomePage
{
    public class BBCHomePageHeader : AbstractFragment
    {
        private static By NewsLink = By.XPath("//ul//li//a");
        private static By SportsLink = By.CssSelector("ul > li.orb-nav-sport > a");
        private static By WeatherLink = By.CssSelector("ul > li.orb-nav-weather > a");

        [FindsBy(How = How.XPath, Using = "//div/nav/div[1]/div")]
        private IWebElement _BBCHompageHeaderRoot;

        protected override void InitializeFragment()
        {
            SetRootElement(_BBCHompageHeaderRoot);
        }

        internal Button GetNewsLink() => GetChildElements<Button>(NewsLink).Find(x => x.Text.ToLower().Contains("news"));
            
            
        //    GetChildElement<Button>(NewsLink);
        internal Button GetSportsLink() => GetChildElements<Button>(NewsLink).Find(x => x.Text.ToLower().Contains("sport"));
        internal Button GetWeatherLink() => GetChildElements<Button>(NewsLink).Find(x => x.Text.ToLower().Contains("weather"));
    }
}