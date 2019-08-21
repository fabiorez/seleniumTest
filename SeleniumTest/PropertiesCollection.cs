using OpenQA.Selenium;

namespace SeleniumTest
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }
    class PropertiesCollection
    {
        //auto-implement properties
        public static IWebDriver driver { get; set; }

        public static By FindBy(string element, PropertyType elementType)
        {
            By by;

            switch (elementType)
            {
                case PropertyType.Id:
                    by = By.Id(element);
                    break;
                case PropertyType.Name:
                    by = By.Name(element);
                    break;
                case PropertyType.LinkText:
                    by = By.LinkText(element);
                    break;
                case PropertyType.CssName:
                    by = By.LinkText(element);
                    break;
                case PropertyType.ClassName:
                    by = By.LinkText(element);
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            return by;
        }
    }

    class Base
    {
        public static By FindBy(string element, PropertyType elementType)
        {
            By by;

            switch (elementType)
            {
                case PropertyType.Id:
                    by = By.Id(element);
                    break;
                case PropertyType.Name:
                    by = By.Name(element);
                    break;
                case PropertyType.LinkText:
                    by = By.LinkText(element);
                    break;
                case PropertyType.CssName:
                    by = By.LinkText(element);
                    break;
                case PropertyType.ClassName:
                    by = By.LinkText(element);
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            return by;
        }
    }
}


