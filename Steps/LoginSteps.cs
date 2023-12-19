using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using lab2_Testing.PageObjects;


namespace lab2_Testing.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginObject loginPage;

        [Given("I navigate to the SauceDemo login page")]
        public void GivenINavigateToTheSauceDemoLoginPage()
        {
            driver = new ChromeDriver("D:/LPNU/Тестування/chromedriver-win64/chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginObject(driver);
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            loginPage.Login(username, password);
        }
       
        [When(@"I add an item to the cart")]
        public void WhenIAddAnItemToTheCart()
        {
            loginPage.AddItemToCart();
        }

        [Then("I should be redirected to the inventory page")]
        public void ThenIShouldBeRedirectedToTheInventoryPage()
        {
            Assert.IsTrue(loginPage.IsUserRedirectedToInventory());
        }

        

        [Then("I should see the error message")]
        public void ThenIShouldSeeTheErrorMessage()
        {
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed());
        }

        [After]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
