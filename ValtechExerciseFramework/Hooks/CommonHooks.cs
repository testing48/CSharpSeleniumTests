using NUnit.Framework;
using System;
using System.Diagnostics;
using ValtechExerciseFramework.Utils;

namespace ValtechExerciseFramework.StepDefs.Hooks
{
    [SetUpFixture]
    public class CommonHooks
    {
        [OneTimeSetUp]
        public void Init()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(UIConfigurationSettings.Driver.ToLower()))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}