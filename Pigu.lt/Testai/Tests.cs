using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V108.CSS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using System.Reflection.Emit;
using RDE.LT.POM;
using System.Drawing.Imaging;
using NUnit.Framework.Interfaces;

namespace RDE.LT
{
    public class Tests
    {
        private static string driverPath = "C:\\Users\\Mindaugas\\Documents\\chromedriver.exe";
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.rde.lt/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//div[@class='cookie_window']//a[2]")).Click();
        }

        [TearDown]
        public static void TearDown()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(@"C:\Users\Mindaugas\Documents\Screenshot.jpg", ScreenshotImageFormat.Jpeg);
            }
        }

        [Test]
        public static void SearchAndValidate()
        {
            TopMenu topMenu = new TopMenu(driver);
            ProductList productList = new ProductList(driver);
            ProductCard productCard = new ProductCard(driver);

            topMenu.SearchByText("Iphone 11");
            productList.SelectProduct(1);
            productCard.CheckBreadcrumbsCount(3);
            productCard.CheckIfNameExists();
            productCard.CheckIfImageExists();
            productCard.CheckIfOffersExists();
            productCard.CheckIfAddCartExists();
            productCard.CheckIfSpecsExists();
            productCard.CheckIfSimilarItemsExists();
            productCard.CheckIfSuggestedItemsExists();
            productCard.CheckIfHeaderExists();
            productCard.CheckIfPromoExists();
        }

        [Test]
        public static void LoginAndLogOff()
        {
            LoginClass loginas = new LoginClass(driver);

            loginas.EnterEmailAndPassword();
            loginas.CheckIfLogged();
            loginas.Logout();
        }

        [Test]
        public static void NavigationWithHover()
        {
            Navigation navigacija = new Navigation(driver);
            GeneralMethods generalMethods = new GeneralMethods(driver);
            ProductCard productCard = new ProductCard(driver);
            ProductList productList = new ProductList(driver);

            navigacija.HoverTopCategory("//a[text()='Kompiuterinė technika']");
            generalMethods.ClickElement("(//div[@class='nav-secondary']//a)[1]");
            productCard.CheckBreadcrumbsCount(3);
            productList.SelectProduct(1);
            productCard.CheckIfNameExists();
            productCard.CheckIfAddCartExists();
        }

        [Test]
        public static void CheckIfPricesAreAscending() {
            Navigation navigacija = new Navigation(driver);
            GeneralMethods generalMethods = new GeneralMethods(driver);
            Sort sort = new Sort(driver);

            navigacija.HoverTopCategory("//a[text()='Kompiuterinė technika']");
            generalMethods.ClickElement("(//div[@class='nav-secondary']//a)[1]");
            generalMethods.ClickElement("//span[@class='current']");
            generalMethods.ClickElement("//li[text()='Didėjanti kaina']");
            Thread.Sleep(5000);
            sort.CheckIfAscending();
            navigacija.NextPage();
            sort.CheckIfAscending();
            navigacija.NextPage();
            sort.CheckIfAscending();
            navigacija.NextPage();
            sort.CheckIfAscending();
        }
    }
}

