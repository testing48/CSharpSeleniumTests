using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using ValtechExerciseFramework.Helpers;

namespace ValtechExerciseFramework.Utils
{
    public class WebDriverFactory
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public static IKernel ninjectKernel;

        public static IWebDriver WebDriver => _driver.Value;

        public static void CloseBrowser() => _driver.Value.Quit();

        public static IWebDriver InitDriver()
        {
            try
            {
                Logger.InitLogger();
                ninjectKernel = new StandardKernel();
                ninjectKernel.Load(AppDomain.CurrentDomain.GetAssemblies());

                Logger.Log.Info("Initializing driver instance...");
                var driver = UIConfigurationSettings.Driver.ToLower();

                switch (driver)
                {
                    case "chrome":
                        {
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddUserProfilePreference("download.default_directory", FoldersPathHelper.Downloads);
                            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                            chromeOptions.AddArguments("--disable-notifications");
                            _driver.Value = new ChromeDriver(FoldersPathHelper.Drivers, chromeOptions);
                            _driver.Value.Manage().Window.Maximize();
                            break;
                        }
                    default:
                        throw new Exception("Browser is not supported or it's name in configuration file is incorrect!");
                }
                return _driver.Value;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Failed to create driver instance!", ex);
                throw ex;
            }
        }
    }
}