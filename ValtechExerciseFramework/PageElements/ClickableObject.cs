using OpenQA.Selenium;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.PageElements
{
    public class ClickableObject : BaseWebElement
    {
        public ClickableObject(By locator)
            : base(locator)
        {

        }

        protected ClickableObject(IWebElement webElement)
            : base(webElement)
        {

        }

        public virtual void Click()
        {
            var executor = (IJavaScriptExecutor)WebDriverFactory.WebDriver;
            executor.ExecuteScript("arguments[0].click();", WebElement);
        }
    }
}

