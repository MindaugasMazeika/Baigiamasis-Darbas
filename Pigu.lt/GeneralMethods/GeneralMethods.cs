using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RDE.LT
{
    internal class GeneralMethods
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> wait;
        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(950);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
        }

        public void ClickElementByJs(string xpath)
        {
            IWebElement el = driver.FindElement(By.XPath(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();

        }

        public void ClickElement(string xpath)
        {
            wait.Message = "Element cannot be found";
            IWebElement name = wait.Until(x => x.FindElement(By.XPath(xpath)));
            name.Click();
        }

        public void EnterText(string xpath, string text)
        {
            By searchField = By.XPath(xpath);
            driver.FindElement(searchField).SendKeys(text);

        }
        public int GetElementsCountByXpath(string xpath)
        {
            By elements = By.XPath(xpath);
            return driver.FindElements(elements).Count();
        }
        public void CheckElementExistsByXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath));

        }
        public void CheckIfElementExists(string xpath)
        {
            wait.Message = "Element cannot be found";
            IWebElement name = wait.Until(x => x.FindElement(By.XPath(xpath)));
        }
    }
}
