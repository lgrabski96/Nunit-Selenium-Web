using OpenQA.Selenium;

namespace Nunit_Selenium_Web.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
