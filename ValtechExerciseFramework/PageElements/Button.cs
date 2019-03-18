using OpenQA.Selenium;

namespace ValtechExerciseFramework.PageElements
{
    public class Button : ClickableObject
    {
        public Button(By locator) : base(locator)
        {
        }

        protected Button(IWebElement webElement) : base(webElement)
        {
        }

        public override void Click() => WebElement.Click();
    }
}