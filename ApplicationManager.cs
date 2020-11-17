using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace Gruyere
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public IDictionary<string, object> vars {get; private set;}
        private IJavaScriptExecutor js;
        private LoginHelper auth;
        private NavigationHelper navigation;
        private SnippetHelper snippets;

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }

            return app.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                //ignore
            }
        }

        private ApplicationManager()
        {
            driver = new ChromeDriver("/Users/faritshamardanov/Downloads");
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this);
            snippets = new SnippetHelper(this);
        }

        public IWebDriver Driver => driver;

        public LoginHelper Auth => auth;

        public NavigationHelper Navigation => navigation;

        public SnippetHelper Snippets => snippets;

        public void Stop()
        {
            driver.Quit();
        }
    }
}