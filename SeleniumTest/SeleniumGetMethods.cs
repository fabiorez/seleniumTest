using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTest
{
    class SeleniumGetMethods
    {
        public static string GetText(FirefoxDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                return driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementType == "Name")
                return driver.FindElement(By.Name(element)).GetAttribute("value");
            else
                return string.Empty;
        }

        public static string GetTextFromDropDown(FirefoxDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;

            if (elementType == "Name")
                return new SelectElement(driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else
                return string.Empty;
        }
    }
}
