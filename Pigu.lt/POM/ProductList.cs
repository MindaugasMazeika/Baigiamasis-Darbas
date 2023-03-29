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
    internal class ProductList
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public ProductList(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void SelectProduct(int x)
        {
            By temp = By.XPath("(//div[@id='main_container_wrapper']//li)[" + x + "]");
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(temp)).Perform();
            driver.FindElement(temp).Click();
        }
    }


}
