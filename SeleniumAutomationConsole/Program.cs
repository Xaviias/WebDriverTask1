using System;
using WebDriverTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up WebDriver
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    // Instantiate the page object
                    var pastebinPage = new PastebinHomePage(driver);

                    // Navigate to Pastebin
                    pastebinPage.NavigateToPage();

                    // Enter the code to paste
                    pastebinPage.EnterPasteCode("Hello from WebDriver");

                    // Set expiration
                    pastebinPage.SelectPasteExpiration();

                    // Enter the paste name/title
                    pastebinPage.EnterPasteName("helloweb");

                    // Create the new paste
                    pastebinPage.CreateNewPaste();

                    // Validate creation (check if the new paste is displayed)
                    if (driver.Title.Contains("helloweb"))
                    {
                        Console.WriteLine("Paste created successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Paste creation failed.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Test failed: " + ex.Message);
                }
                finally
                {
                    // Clean up
                    driver.Quit();
                }
            }
        }
    }
}

