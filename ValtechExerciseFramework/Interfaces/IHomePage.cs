namespace ValtechExerciseFramework.Interfaces

{
    public interface IHomePage : IValtechPage
    {
        void AcceptCookies();

        void ClickOnBlog(string number);

        string CheckBlogTitleIsDisplayed();

        void ClickTopNavigationBarLink(string linkName);

        void ClickSportsLink();
    }
}
