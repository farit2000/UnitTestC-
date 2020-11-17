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
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            
        }
        public void SetWindowSize()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1619, 933);
        }
        
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("Home")).Click();
        }
        
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://google-gruyere.appspot.com/440653773172947326872184277494671579888/");
        }
    }
}