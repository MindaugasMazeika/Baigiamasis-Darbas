using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDE.LT.POM
{
    internal class Navigation
    {
        IWebDriver driver;
      
        public Navigation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void HoverTopCategory(string Xpath)
        {
            By Topmenu = By.XPath(Xpath);
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(Topmenu)).Perform();
        }

        public void NextPage() 
        {
            By nextPage = By.XPath("//a[contains(@class,'square js-next')]");
            driver.FindElement(nextPage).Click();
        }
    }

}