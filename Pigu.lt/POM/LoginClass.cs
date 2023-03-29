using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDE.LT.POM
{
    internal class LoginClass
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public LoginClass(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        string[] userdata = System.IO.File.ReadAllLines(@"C:\Users\Mindaugas\source\repos\Pigu.lt\Pigu.lt\Data\LoginData.txt");
        public void EnterEmailAndPassword()
        {
            driver.FindElement(By.XPath("//a[text()=' Įeiti ']")).Click();
            By enterEmail = By.Id("loginEmail");
            driver.FindElement(enterEmail).SendKeys(userdata[0]);
            By enterPassword = By.XPath("(//input[@type='password'])[1]");
            driver.FindElement(enterPassword).SendKeys(userdata[1]);
            driver.FindElement(By.XPath("(//button[@type='submit'])[1]")).Click();
        }

        public void CheckIfLogged()
        {
            generalMethods.CheckIfElementExists("//span[text()='Paskyros valdymas']");
        }

        public void Logout()
        {
            generalMethods.ClickElement("//span[text()='Paskyros valdymas']");
            generalMethods.ClickElement("//div[@class='account__menu__footer']");
            generalMethods.CheckIfElementExists("//a[text()=' Įeiti ']");
        }
    }
}
