using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;


namespace lab2_Testing.PageObjects
{
    public class LoginObject
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginObject(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

       

        public IWebElement UserNameElement => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordElement => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement InventoryContainer => driver.FindElement(By.Id("inventory_container"));
        public IWebElement ErrorMessageContainer => driver.FindElement(By.ClassName("error-message-container"));

        public void Login(string username, string password)
        {
            UserNameElement.SendKeys(username);
            PasswordElement.SendKeys(password);
            LoginButton.Click();
        }

        public bool IsUserRedirectedToInventory()
        {
            return InventoryContainer.Displayed;
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                return ErrorMessageContainer.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void AddItemToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                
                By addToCartButtonSelector = By.XPath("//*[@id='add-to-cart-sauce-labs-backpack']");
                IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addToCartButtonSelector));

                addToCartButton.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//your/unique/xpath")));

                IWebElement successMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".success-message")));

                if (successMessage.Displayed)
                {
                    Console.WriteLine("Товар успішно додано до кошика.");
                }
                else
                {
                    Console.WriteLine("Помилка: товар не додано до кошика.");
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout exception: Add to cart button not found or not clickable.");
            }
        }





    }
}
