using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace ValtechExerciseFramework.Pages.AboutPage.ContactUsPage
{
    public class ContactUsPageOfficeLocationFragment : AbstractFragment
    {
        private static By NumberOfOfficesText = By.CssSelector(".office-country__container .office__description");

        [FindsBy(How = How.CssSelector, Using = "#container")]
        private IWebElement _contactUsPageOfficeLocationFragment;

        protected override void InitializeFragment()
        {
            SetRootElement(_contactUsPageOfficeLocationFragment);
        }

        internal IList<ContactUsPageOfficeLocationFragment> GwtContactUsPageOfficeLocationFragment()
        {
            return GetFragmentFactory()
                    .CreateFragments
                            (GetChildElements(NumberOfOfficesText), new ContactUsPageOfficeLocationFragment());
        }
    }
}