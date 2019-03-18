using ValtechExerciseFramework.Pages;

namespace ValtechExerciseFramework.Interfaces
{
    public interface IValtechPage
    {
        FragmentFactory GetFragmentFactory();

        string GetCurrentUrl();

        void Check();

        void ClearCookies();

        void ClosePage();

        void WaitForComplete();
    }
}