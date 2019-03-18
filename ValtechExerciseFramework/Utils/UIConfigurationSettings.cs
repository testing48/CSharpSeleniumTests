using System;
using System.Collections.Generic;
using System.Configuration;

namespace ValtechExerciseFramework.Utils
{
    public static class UIConfigurationSettings
    {

        private static string GetValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (NullReferenceException)
            {
                throw new KeyNotFoundException($"Key {key} is not found in App.config");
            }
        }

        #region URLs
        public static string ValtechContactUsUrl => GetValue("valtechContactUsUrl");
        public static string ValtechHomeUrl => GetValue("valtechHomeUrl");
        public static string ValtechWorkUrl => GetValue("valtechWorkUrl");
        public static string valtechAboutUrl => GetValue("valtechAboutUrl");
        public static string valtechServicesUrl => GetValue("valtechServicesUrl");
        #endregion

        #region Browser Settings
        public static string Driver => GetValue("driver");
        #endregion
    }
}