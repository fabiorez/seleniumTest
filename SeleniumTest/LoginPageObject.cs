using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTest
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement btnLogin { get; set; }

        public EAPageObject Login(string userName, string password)
        {
            //Login
            txtUserName.SendKeys(userName);
            //Password
            txtPassword.SendKeys(password);
            //Click button
            btnLogin.Submit();

            //Return page object
            return new EAPageObject();
        }
    }
}
