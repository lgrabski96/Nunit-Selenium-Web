using Nunit_Selenium_Web.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Nunit_Selenium_Web.Tests
{
    public class BaseTest {
        private IWebDriver driver;

        private const string url = "https://www.saucedemo.com/";

        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        [SetUp]
        public void Setup()
        {
            //Initialize Web Driver
            driver = new ChromeDriver();

            //Initite Pages
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [Test]
        public void BasicTest()
        {
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "secret_sauce");
            loginPage.LoginButtonClick();

            WebDriverWait.Equals(inventoryPage.IsTitleDisplayed, true);
            Assert.True(inventoryPage.IsTitleDisplayed);

            //WebDriverWait.Equals(driver.FindElement(inventoryPage.ProductsTitleElement);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //TearDown();

            //Assert.Pass();
        }

        [Test]
        public void Login_AsStandardUser_ShouldRedirectToInventoryPage()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);

            //Act
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "secret_sauce");
            loginPage.LoginButtonClick();

            //Assert
            Assert.That(inventoryPage.ProductsTitleText, Is.EqualTo("PRODUCTS"));
        }

        [Test]
        public void Login_AsLockedOutUser_ShouldDisplayLockedOutMessage()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(driver);

            //Act
            driver.Navigate().GoToUrl(url);

            loginPage.Login("locked_out_user", "secret_sauce");
            loginPage.LoginButtonClick();

            //Assert
            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        }

        [Test]
        public void Login_InvalidPassword_ShouldDisplayUsernameandPasswordErrorMessage()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(driver);

            //Act
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "a");
            loginPage.LoginButtonClick();

            //Assert
            Assert.That(loginPage.ErrorMessage.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [TearDown] public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}