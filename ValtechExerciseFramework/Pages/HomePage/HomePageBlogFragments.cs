using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using ValtechExerciseFramework.PageElements;

namespace ValtechExerciseFramework.Pages.HomePages
{
    public class HomePageBlogFragments : AbstractFragment
    {
        private static By BlogsTitleText = By.CssSelector(".block-header h2");
        private static By BlogsList = By.CssSelector(".bloglisting-compact");
        private static By BlogsItemHeadingLink = By.CssSelector(".bloglisting-compact .bloglisting__item__heading  a");

        [FindsBy(How = How.CssSelector, Using = ".startpage__bloglisting")]
        private IWebElement _homePageBlogFragments;

        protected override void InitializeFragment()
        {
            SetRootElement(_homePageBlogFragments);
        }

        internal TextObject GetBlogsTitleText() => GetChildElement<TextObject>(BlogsTitleText);

        internal IList<HomePageBlogFragments> GetHomePageBlogFragments()
        {
            return GetFragmentFactory()
                    .CreateFragments
                            (GetChildElements(BlogsList), new HomePageBlogFragments());
        }

        internal ClickableObject GetBlogsItemHeadingLink() => GetChildElement<ClickableObject>(BlogsItemHeadingLink);
    }
}