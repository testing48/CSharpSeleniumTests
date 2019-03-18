using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.Pages
{
    public abstract class AbstractPage
    {
        private const long _redirectTimeoutInSeconds = 120;
        private const string _statusComplete = "complete";

        private FragmentFactory _fragmentFactory = new FragmentFactory();
        private PageWaitUtils _pageWaitUtils = new PageWaitUtils();
        private WebDriverUtils _webDriverUtils = new WebDriverUtils();
        private string _relativeUrl;
        private string _urlFormat;

        public AbstractPage()
        {
            InitializePage();
            PageFactory.InitElements(WebDriverFactory.WebDriver, this);
        }

        protected virtual void InitializePage()
        {
            // Can be overridden in child page
        }

        public FragmentFactory GetFragmentFactory() => _fragmentFactory;

        protected string GetUrl() => GetRelativeUrl();

        protected void SetUrl(string relativeURL) => _relativeUrl = relativeURL;

        private string GetRelativeUrl()
        {
            if (_relativeUrl != null)
            {
                return _relativeUrl;
            }
            throw new Exception("Please set page URL using appropriate method. Page URL must not be null.");
        }

        private string GetUrlFormat()
        {
            if (_urlFormat == null)
            {
                return string.Empty;
            }
            return _urlFormat;
        }

        private bool HasUrlFormat() => !(string.IsNullOrEmpty(GetUrlFormat()));

        public void Check()
        {
            if (HasUrlFormat())
            {
                if (!IsCurrentByFormat())
                {
                    throw new Exception(
                            string.Format("Current page is wrong by URL format.\nExpected URL format: {0}\nCurrent URL: {1}",
                                    GetUrlFormat(), WebDriverFactory.WebDriver.Url));
                }
                Logger.Log.Info(new object[] { string.Format("The page {0} suits format {1}.", GetCurrentUrl(), GetUrlFormat()) });
            }
            else if (!WebDriverFactory.WebDriver.Url.Contains(GetRelativeUrl()))
            {
                throw new Exception("Current page is wrong by URL format.");
            }
        }

        public void ClearCookies()
        {
            IReadOnlyCollection<Cookie> allCookies = WebDriverFactory.WebDriver.Manage().Cookies.AllCookies;
            foreach (Cookie cookie in allCookies)
            {
                WebDriverFactory.WebDriver.Manage().Cookies.DeleteCookieNamed(cookie.Name);
            }
        }

        public void ClosePage() => WebDriverFactory.WebDriver.Close();

        public string GetCurrentUrl() => WebDriverFactory.WebDriver.Url;

        public bool IsCurrentByFormat() => Regex.IsMatch(WebDriverFactory.WebDriver.Url, GetUrlFormat());

        public void SetUrlFormat(string urlFormat) => _urlFormat = urlFormat;

        public void WaitForComplete() => _pageWaitUtils.ForPageStatusChange(_statusComplete, _redirectTimeoutInSeconds);
    }
}