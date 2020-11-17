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
    public class SnippetHelper : HelperBase
    {
        public SnippetHelper(ApplicationManager manager) : base(manager)
        {
            
        }
        
        public void RemoveSnippet()
        {
            driver.FindElement(By.LinkText("[X]")).Click();
        }

        public void RefreshSnippets()
        {
            driver.FindElement(By.LinkText("Refresh")).Click();
        }

        public void CreateNewSnippet(SnippetData snippet)
        {
            driver.FindElement(By.LinkText("New Snippet")).Click();
            driver.FindElement(By.Name("snippet")).Click();
            driver.FindElement(By.Name("snippet")).SendKeys(snippet.SnippetText);
            driver.FindElement(By.CssSelector("input")).Click();
        }

        public SnippetData GetSnippetCreatedData()
        {
            string snippetText = driver.FindElement(By.Id("0")).Text.Trim(' ');
            return new SnippetData(snippetText);
        }
    }
}