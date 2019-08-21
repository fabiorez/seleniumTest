using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;


namespace SeleniumTest
{
    class SeleniumGetMethods
    {
        public static string GetText(string element, PropertyType elementType)
        {
            By by = Base.FindBy(element, elementType);

            return PropertiesCollection.driver.FindElement(by).GetAttribute("value");
        }



        public static string GetTextFromDropDown(string element, PropertyType elementType)
        {
            By by = Base.FindBy(element, elementType);

            return new SelectElement(PropertiesCollection.driver.FindElement(by)).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
