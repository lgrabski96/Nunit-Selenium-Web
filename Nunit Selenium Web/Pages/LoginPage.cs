using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_Selenium_Web.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameField => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));

        // Wyszukiwanie relatywne
        public IWebElement RelativePasswordField => driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Below(By.Id("user-name")));
        public IWebElement RelativeUserName => driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Above(By.Id("password")));
        public IWebElement NearUserName => driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Near(By.Id("password"), 200));

        public void Login(string userName, string password)
        {
            //    UserNameField.SendKeys(userName);
            // PasswordField.SendKeys(password);

            RelativeUserName.SendKeys(userName);
            RelativePasswordField.SendKeys(password);
        }
        public void LoginButtonClick()
        {
            LoginButton.Click();
        }

    }
}
