using OpenQA.Selenium;

namespace ValtechExerciseFramework.PageElements
{
    public class TextObject : BaseWebElement
    {
        public TextObject(By locator, bool firstDisplayed = false)
            : base(locator, firstDisplayed)
        {

        }

        protected TextObject(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}