using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace ValtechExerciseFramework.Utils
{
    public class PageWaitUtils
    {
        private const long _defaultSleepInMilliseconds = 100;
        private const long _defaultWaitInSeconds = 120;
        private const string _statusComplete = "complete";
        private const string _defaultMessage = "ExpectedCondition didn't happen during timeout!";

        public T Until<T>(Func<IWebDriver, T> condition)
        {
            return GetFluentWait(_defaultWaitInSeconds).Until(condition);
        }

        public void ForPageStatusChange(string status, long timeoutInSeconds)
        {
            Func<IWebDriver, bool> pageStatusChangeCondition = PageStatus(status);
            Logger.Log.Info("Waiting for page became: " + status);
            GetFluentWait(timeoutInSeconds).Until(pageStatusChangeCondition);
        }

        public void ForRedirected(string expectedUrlFormat, long timeoutInSeconds)
        {
            Func<IWebDriver, bool> pageURLFormatCondition = PageUrlFormat(expectedUrlFormat);
            Logger.Log.Info("Waiting for page is redirected to: " + expectedUrlFormat);
            GetFluentWait(timeoutInSeconds).Until(pageURLFormatCondition);
        }

        private string GetDocumentReadyState() => (string)((IJavaScriptExecutor)WebDriverFactory.WebDriver).ExecuteScript("return document.readyState");

        private WebDriverWait GetFluentWait(long seconds)
        {
            return new WebDriverWait(new SystemClock(), WebDriverFactory.WebDriver, TimeSpan.FromSeconds(seconds), TimeSpan.FromMilliseconds(_defaultSleepInMilliseconds));
        }

        private Func<IWebDriver, bool> PageUrlFormat(string expectedUrlFormat) => driver => Regex.IsMatch(WebDriverFactory.WebDriver.Url, expectedUrlFormat);

        private Func<IWebDriver, bool> PageStatus(string status) => driver => GetDocumentReadyState().Equals(status);

        public bool IsAlertPresent()
        {
            try
            {
                WebDriverWait wait = GetFluentWait(_defaultWaitInSeconds);
                if (wait.Until(ExpectedConditions.AlertIsPresent()) != null)
                    return true;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
            }
            return false;
        }

        public void WaitForJQuery()
        {
            GetFluentWait(_defaultWaitInSeconds).Until(driver =>
            {
                return (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0") == false;
            });
        }
    }
}