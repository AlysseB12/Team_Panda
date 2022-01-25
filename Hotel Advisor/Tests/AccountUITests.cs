using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Hotel_Advisor.Tests
{
    public class AccountUITests : IDisposable
    {
        private readonly IWebDriver driver;

        public AccountUITests() => driver = new ChromeDriver();

        public void Dispose()
        {
        }

        [Fact]
        public void LoggingInAsExistingUser_LogsIn()
        {
            driver.Navigate().GoToUrl("https://localhost:7292/Identity/Account/Login");

            driver.FindElement(By.Id("Input_Username"))
                .SendKeys("alysse@test.co.uk");

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("Advisor-2012");

            driver.FindElement(By.Id("login-submit"))
                .Click();

            var welcomeText = driver.FindElement(By.Id("manage")).Text;

            Assert.Equal("Hello alysse@test.co.uk!", welcomeText);
        }

        [Fact]
        public void RegisterAsAUser()
        {
            var username = Guid.NewGuid();

            driver.Navigate().GoToUrl("https://localhost:7292/Identity/Account/Register");

            driver.FindElement(By.Id("Input_Username"))
                .SendKeys(username.ToString());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys(username.ToString() + "@test.co.uk");

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("Advisor-2022");

            driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys("Advisor-2022");

            driver.FindElement(By.Id("registerSubmit"))
                .Click();

            var welcomeText = driver.FindElement(By.Id("manage")).Text;

            var expectedText = "Hello " + username.ToString() + "!";

            Assert.Equal(expectedText, welcomeText);
        }
    }
}
