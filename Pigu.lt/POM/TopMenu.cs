using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDE.LT.POM
{
    internal class TopMenu
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public TopMenu(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void SearchByText(string text)
        {
            generalMethods.EnterText("//input[@name='search_string']", text);
            generalMethods.ClickElementByJs("//button[@data-plugin='searchSubmitButton']");


        }
    }
}
