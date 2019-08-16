using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class SeleniumSetMethods
    {
        //EnterText
        public static void EnterText(string element, string value, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
                    break;
                case PropertyType.Name:
                    PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
                    break;
            }
        }

        //Click into a button, Checkbox, option etc
        public static void Click(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.driver.FindElement(By.Id(element)).Click();
                    break;
                case PropertyType.Name:
                    PropertiesCollection.driver.FindElement(By.Name(element)).Click();
                    break;
            }
        }

        //Selecting a drop down control
        public static void SelectDropDown(string element, string value, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
                    break;
                case PropertyType.Name:
                    new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
                    break;
            }
        }
    }
}
