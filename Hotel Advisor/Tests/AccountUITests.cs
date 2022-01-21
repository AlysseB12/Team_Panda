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
        }
    }
}
