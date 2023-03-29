using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDE.LT.POM
{
    internal class ProductCard
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void CheckBreadcrumbsCount(int x)
        {
            int CountOfBreadcrumbs = generalMethods.GetElementsCountByXpath("//li[@itemprop='itemListElement']");
            Assert.AreEqual(x, CountOfBreadcrumbs, "Expected 3 breadcrumbs, but got : " + CountOfBreadcrumbs);
        }

        public void CheckIfNameExists()
        {
            generalMethods.CheckIfElementExists("//h1[@itemprop='name']");
        }

        public void CheckIfImageExists()
        {
            generalMethods.CheckIfElementExists("//img[@itemprop='image']");
        }

        public void CheckIfOffersExists()
        {
            generalMethods.CheckIfElementExists("//div[@itemprop='offers']");
        }

        public void CheckIfAddCartExists()
        {
            generalMethods.CheckIfElementExists("//div[contains(@class,'product-info')]//span[text()='Pridėti į krepšelį']");
        }
        public void CheckIfSpecsExists()
        {
            generalMethods.CheckIfElementExists("//div[@id='content-tabs']");
        }
        public void CheckIfSimilarItemsExists()
        {
            generalMethods.CheckIfElementExists("(//div[contains(@class,'retailrocket-items')])[1]");
        }
        public void CheckIfSuggestedItemsExists()
        {
            generalMethods.CheckIfElementExists("(//div[contains(@class,'retailrocket-items')])[2]");
        }

        public void CheckIfHeaderExists()
        {
            generalMethods.CheckIfElementExists("//header[@class='header']");  
        }

        public void CheckIfPromoExists()
        {
            generalMethods.CheckIfElementExists("//div[@class='promo-sale ui-footer']");
        }
    }
}
