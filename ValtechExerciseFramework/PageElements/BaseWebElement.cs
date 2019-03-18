using OpenQA.Selenium;
using System.Linq;
using ValtechExerciseFramework.Utils;


namespace ValtechExerciseFramework.PageElements
{
    public class BaseWebElement
    {
        protected IWebElement WebElement;

        public BaseWebElement(By locator, bool firstDisplayed = false)
        {
            WebElement = firstDisplayed
                ? WebDriverFactory.WebDriver.FindElements(locator).First(element => element.Displayed)
                : WebDriverFactory.WebDriver.FindElement(locator);
        }

        protected BaseWebElement(IWebElement webElement)
        {
            WebElement = webElement;
        }

        public bool IsDisplayed => WebElement.Displayed;

        public bool IsEnabled => WebElement.Enabled;

        public bool IsDisabled => !WebElement.Enabled;

        public string Text => WebElement.Text;
    }
}