using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class SeleniumSetMethods
    {
        //EnterText
        public static void EnterText(string element, string value, PropertyType elementType)
        {
            By by = Base.FindBy(element, elementType);

            PropertiesCollection.driver.FindElement(by).SendKeys(value);
        }

        //Click into a button, Checkbox, option etc
        public static void Click(string element, PropertyType elementType)
        {
            By by = Base.FindBy(element, elementType);

            PropertiesCollection.driver.FindElement(by).Click();
        }

        //Selecting a drop down control
        public static void SelectDropDown(string element, string value, PropertyType elementType)
        {
            By by = Base.FindBy(element, elementType);

            new SelectElement(PropertiesCollection.driver.FindElement(by)).SelectByText(value);
        }
    }
}
