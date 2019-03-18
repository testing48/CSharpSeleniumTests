using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValtechExerciseFramework.PageElements;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.Pages
{
    public class AbstractFragment
    {
        private const int _webElementTimeout = 60;
        private FragmentFactory _fragmentFactory = new FragmentFactory();

        private IWebElement _rootElement;

        public AbstractFragment()
        {
            PageFactory.InitElements(WebDriverFactory.WebDriver, this);
            InitializeFragment();
        }

        protected virtual void InitializeFragment()
        {
            //Should be overridden if necessary in child
        }

        protected FragmentFactory GetFragmentFactory() => _fragmentFactory;

        protected IWebElement GetRootElement() => _rootElement;

        public void SetRootElement(IWebElement rootElement) => _rootElement = rootElement;

        public IWebElement GetChildElement(By locator)
        {
            var pageObject = _rootElement.FindElement(locator);
            return pageObject;
        }

        public T GetChildElement<T>(By locator) where T : BaseWebElement
        {
            var child = _rootElement.FindElement(locator);
            var pageObject = CreatePageObject<T>(child);
            return pageObject;
        }

        public List<IWebElement> GetChildElements(By locator)
        {
            var pageObjects = _rootElement.FindElements(locator);
            return pageObjects.ToList();
        }

        public List<T> GetChildElements<T>(By locator) where T : BaseWebElement
        {
            var children = _rootElement.FindElements(locator);
            var pageObjects = children.Select(CreatePageObject<T>);
            return pageObjects.ToList();
        }

        private static T CreatePageObject<T>(IWebElement child) where T : BaseWebElement
        {
            var ctor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance, null, new[] { typeof(IWebElement) }, null);
            var pageObject = (T)ctor.Invoke(new object[] { child });
            return pageObject;
        }
    }
}