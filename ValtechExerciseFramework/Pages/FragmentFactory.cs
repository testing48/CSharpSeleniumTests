using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValtechExerciseFramework.Pages
{
    public class FragmentFactory
    {
        public T CreateFragment<T>(IWebElement rootElement, T type) where T : AbstractFragment
        {
            T instance = CreateFragment(type);
            instance.SetRootElement(rootElement);
            return instance;
        }

        public T CreateFragment<T>(T type) where T : AbstractFragment
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T), new object[] { });
            }
            catch (Exception)
            {
                throw new Exception("Unable to create an instance of class " + type);
            }
        }

        public IList<T> CreateFragments<T>(IList<IWebElement> elements, T type) where T : AbstractFragment
        {
            return elements.Select(element => CreateFragment(element, type)).ToList();
        }
    }
}