namespace ValtechExerciseFramework.Utils
{
    public class WebDriverUtils
    {
        public string GetTitle() => WebDriverFactory.WebDriver.Title;

        public void DeleteCookies() => WebDriverFactory.WebDriver.Manage().Cookies.DeleteAllCookies();

        public string GetCurrentUrl() => WebDriverFactory.WebDriver.Url;

        public void Navigate(string url) => WebDriverFactory.WebDriver.Navigate().GoToUrl(url);
    }
}