using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTest
{
    class SeleniumGetMethods
    {
        public static string GetText(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
                case PropertyType.Name:
                    return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
                default:
                    return string.Empty;
            }
        }

        public static string GetTextFromDropDown(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
                case PropertyType.Name:
                    return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
                default:
                    return string.Empty;
            }
        }
    }
}
