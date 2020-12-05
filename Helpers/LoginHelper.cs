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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
            
        }
        public void SignIn(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account.Username))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Name("uid")).Click();
            driver.FindElement(By.Name("uid")).SendKeys(account.Username);
            driver.FindElement(By.Name("pw")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("tr:nth-child(3) input")).Click();
        }

        public void SignUp(AccountData account)
        {
            driver.FindElement(By.LinkText("Sign up")).Click();
            driver.FindElement(By.Name("uid")).Click();
            driver.FindElement(By.Name("uid")).SendKeys(account.Username);
            driver.FindElement(By.Name("pw")).Click();
            driver.FindElement(By.Name("pw")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("tr:nth-child(4) input")).Click();
        }

        public void Logout()
        {
            if (IsElementPresent(By.LinkText("Sign out")))
            {
                driver.FindElement(By.LinkText("Sign out")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            if (IsElementPresent(By.LinkText("Sign out")))
            {
                return true;
            }
            return false;
        }

        public bool IsLoggedIn(string username)
        {
            if (IsElementPresent(By.ClassName("menu-user")))
            {
                var logingUserName = driver.FindElement(By.ClassName("menu-user")).Text;
                logingUserName = logingUserName.Split(" ")[0];
                return username == logingUserName;
            }
            return false;
        }
    }
}