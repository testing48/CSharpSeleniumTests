using System;

namespace ValtechExerciseFramework.Helpers
{
    public static class FoldersPathHelper
    {
        public static string Downloads => "C:/Downloads/";

        public static string Drivers => $"{AppDomain.CurrentDomain.BaseDirectory}Drivers";
    }
}