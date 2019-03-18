using System;

namespace ValtechExerciseFramework.Interfaces
{
    interface IAboutPage : IValtechPage
    {
        void ClickOurOfficesLink();

        string GetAboutPageHeaderTitle();

        int GetCountOfOfficelocations();
    }
}
