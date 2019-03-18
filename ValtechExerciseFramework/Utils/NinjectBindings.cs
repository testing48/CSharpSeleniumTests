using Ninject.Modules;
using ValtechExerciseFramework.Interfaces;

namespace ValtechExerciseFramework.Utils
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomePage>().To<ExercisesImplementation>();

            Bind<IAboutPage>().To<ExercisesImplementation>();

            Bind<IServicesPage>().To<ExercisesImplementation>();

            Bind<IWorkPage>().To<ExercisesImplementation>();
        }
    }
}