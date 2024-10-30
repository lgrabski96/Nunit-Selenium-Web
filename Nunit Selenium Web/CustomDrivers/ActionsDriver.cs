using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Nunit_Selenium_Web.CustomDrivers
{
    
    internal class ActionsDriver
    {
        protected readonly Actions actionsDriver;
        public ActionsDriver(Actions actions) 
        {
            this.actionsDriver = actions;
        }

        public void scrollToElement(IWebElement element) 
        {
            actionsDriver
                .ScrollToElement(element)
                //.MoveToElement(element)
                .Perform();

            //actionsDriver.ScrollToElement(element);
        }
    }
}
