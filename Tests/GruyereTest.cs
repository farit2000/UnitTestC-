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
    public class Tests : TestBase
    {
        [Test]
        public void test()
        {
            app.Navigation.OpenHomePage();
            app.Navigation.SetWindowSize();
            AccountData account = new AccountData("qwerty", "qwerty");
            app.Auth.SignUp(account);
            app.Auth.SignIn(account);
            SnippetData snippet = new SnippetData("Hello world!");
            app.Snippets.CreateNewSnippet(snippet);
            app.Snippets.RefreshSnippets();
            app.Snippets.RemoveSnippet();
            app.Navigation.GoToHomePage();
        }
    }
}