using NUnit.Framework;
using Nunit_Selenium_Web.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Nunit_Selenium_Web.Tests
{
    //[TestClass]
    public class InventoryTests
    {
        private IWebDriver driver;

        private const string url = "https://www.saucedemo.com/";

        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        //[TestInitialize]
        public void Initialize()
        {
            // Install-Package Selenium.WebDriver.ChromeDriver
            driver = new ChromeDriver();

            //Arrange
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "secret_sauce");
            loginPage.LoginButtonClick();
        }

        public void Sort_SelectByPriceOrder_ShouldProductsSortedByPrice(Order sortOrder)
        {
            //Act
            inventoryPage.SortByPrice(sortOrder);

            //Assert
            //if (sortOrder == Order.Ascending)
            //    inventoryPage.inventoryItemPrices.Should().BeInAscendingOrder();
            //else
            //    inventoryPage.inventoryItemPrices.Should().BeInDescendingOrder();
        }

        public void Sort_SelectByNameOrder_ShouldProductsSortedByName(Order sortOrder)
        {
            //Act
            inventoryPage.SortByName(sortOrder);

            //Assert

            // Install-Package FluentAssertions
            //if (sortOrder == Order.Ascending)
            //    inventoryPage.inventoryItemNames.Should().BeInAscendingOrder();
            //else
            //    inventoryPage.inventoryItemNames.Should().BeInDescendingOrder();
        }

        //[TestCleanup]
        public void CleanUp()
        {
            // driver.Quit();
        }

    }
}
