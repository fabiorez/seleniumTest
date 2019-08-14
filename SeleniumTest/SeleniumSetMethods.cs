using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class SeleniumSetMethods
    {

        //EnterText
        public static void EnterText(FirefoxDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementType == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);

        }

        //Click into a button, Checkbox, option etc
        public static void Click(FirefoxDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Id(element)).Click();
            if (elementType == "Name")
                driver.FindElement(By.Name(element)).Click();
        }

        //Selecting a drop down control
        public static void SelectDropDown(FirefoxDriver driver, string element, string value, string elementType)
        {

            if (elementType == "Id")
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);

            if (elementType == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
        }
    }
}
