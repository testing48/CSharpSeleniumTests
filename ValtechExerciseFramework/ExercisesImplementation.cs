using ValtechExerciseFramework.Interfaces;
using ValtechExerciseFramework.Pages;
using ValtechExerciseFramework.Pages.AboutPage;
using ValtechExerciseFramework.Pages.AboutPage.ContactUsPage;
using ValtechExerciseFramework.Pages.CommonFragments;
using ValtechExerciseFramework.Pages.HomePage;
using ValtechExerciseFramework.Pages.HomePages;
using ValtechExerciseFramework.Pages.ServicesPage;
using ValtechExerciseFramework.Pages.WorkPage;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework
{
    public class ExercisesImplementation : AbstractPage, IHomePage, IAboutPage, IServicesPage, IWorkPage
    {
        private const string Path = "/";
        private const string UrlFormat = ".*[\\/$]";

        private AboutPageHeaderFragment GetAboutPageHeaderFragment()
        {
            return GetFragmentFactory().CreateFragment(new AboutPageHeaderFragment());
        }

        private AboutPageOurLocationsFragment GetAboutPageOurLocationsFragment()
        {
            return GetFragmentFactory().CreateFragment(new AboutPageOurLocationsFragment());
        }

        private ContactUsPageOfficeLocationFragment GetContactUsPageOfficeLocationFragment()
        {
            return GetFragmentFactory().CreateFragment(new ContactUsPageOfficeLocationFragment());
        }

        private HomePageAcceptCookies GetHomePageAcceptCookies()
        {
            return GetFragmentFactory().CreateFragment(new HomePageAcceptCookies());
        }

        private HomePageBlogFragments GetHomePageBlogFragments()
        {
            return GetFragmentFactory().CreateFragment(new HomePageBlogFragments());
        }

        private MainHeaderFragment GetMainHeaderFragment()
        {
            return GetFragmentFactory().CreateFragment(new MainHeaderFragment());
        }

        private ServicesPageHeaderFragment GetServicesPageHeaderFragment()
        {
            return GetFragmentFactory().CreateFragment(new ServicesPageHeaderFragment());
        }

        private WorkPageHeaderFragment GetWorkPageHeaderFragment()
        {
            return GetFragmentFactory().CreateFragment(new WorkPageHeaderFragment());
        }

        private BBCHomePageHeader GetBBCHomePageHeader()
        {
            return GetFragmentFactory().CreateFragment(new BBCHomePageHeader());
        }

        public void ClickNewsLink()
        {
            GetBBCHomePageHeader().GetNewsLink().Click();
        }

        public void ClickSportsLink()
        {
            GetBBCHomePageHeader().GetSportsLink().Click();
        }

        public void ClickWeatherLink()
        {
            GetBBCHomePageHeader().GetWeatherLink().Click();
        }

        public void AcceptCookies()
        {
            if (GetHomePageAcceptCookies().GetAcceptCookiesButton().IsDisplayed)
            {
                WebElementWait.UntilElementIsEnabled(GetHomePageAcceptCookies().GetAcceptCookiesButton());
                GetHomePageAcceptCookies().GetAcceptCookiesButton().Click();
            }
        }

        public void ClickOnBlog(string number)
        {
            int num = -1;
            switch (number.ToLower())
            {
                case "first":
                    num = 0;
                    break;
                case "second":
                    num = 1;
                    break;
                case "third":
                    num = 2;
                    break;
                default:
                    break;
            }
            GetHomePageBlogFragments().GetHomePageBlogFragments()[num].GetBlogsItemHeadingLink().Click();
        }

        public string CheckBlogTitleIsDisplayed()
        {
            return GetHomePageBlogFragments().GetBlogsTitleText().Text.ToLower();
        }

        public void ClickOurOfficesLink()
        {
            GetAboutPageOurLocationsFragment().GetOurOfficesLink().Click();
        }

        public void ClickTopNavigationBarLink(string linkName)
        {
            GetMainHeaderFragment().GetHeaderNavigationMenuLinks(linkName).Click();
        }

        public string GetAboutPageHeaderTitle()
        {
            return GetAboutPageHeaderFragment().GetPageHeaderText().Text;
        }

        public int GetCountOfOfficelocations()
        {
            var test = GetContactUsPageOfficeLocationFragment().GwtContactUsPageOfficeLocationFragment();
            int x = GetContactUsPageOfficeLocationFragment().GwtContactUsPageOfficeLocationFragment().Count;
            return GetContactUsPageOfficeLocationFragment().GwtContactUsPageOfficeLocationFragment().Count;
        }

        public string GetServicesPageHeaderTitle()
        {
            return GetServicesPageHeaderFragment().GetPageHeaderText().Text;
        }

        public string GetWorkPageHeaderTitle()
        {
            return GetWorkPageHeaderFragment().GetPageHeaderText().Text;
        }

        protected override void InitializePage()
        {
            SetUrl(Path);
            SetUrlFormat(UrlFormat);
        }  
    }
}