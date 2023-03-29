using NUnit.Framework;
using OpenQA.Selenium;
using RDE.LT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDE.LT.POM
{
    internal class Sort
    {
        IWebDriver driver;
        public Sort(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckIfAscending()
        {
            By pricesText = By.XPath("//p[@class='price']");

            List<double> priceList = new List<double>();

            foreach (IWebElement el in driver.FindElements(pricesText))
            {
                string prices = el.Text.Substring(0, el.Text.Length - 2);
                double pricesDouble = double.Parse(prices);
                priceList.Add(pricesDouble);
            }
            for (int i=0; i<priceList.Count-1; i++)
            {
                if (priceList[i] > priceList[i+1]) 
                {
                    Assert.Fail(" Prices are not in ascending order ");
                }
            
            }
        }




    }
}
