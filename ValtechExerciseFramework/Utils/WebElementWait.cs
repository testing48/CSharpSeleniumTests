using OpenQA.Selenium.Support.UI;
using System;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Utils
{
    public static class WebElementWait
    {
        public static WebDriverWait Wait(int seconds = 30) => new WebDriverWait(WebDriverFactory.WebDriver, TimeSpan.FromSeconds(seconds));

        public static void UntilElementIsEnabled<T>(T element, int timeout = 60) where T : BaseWebElement
        {
            var wait = new WebDriverWait(WebDriverFactory.WebDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(driver => element.IsEnabled);
        }
    }
}