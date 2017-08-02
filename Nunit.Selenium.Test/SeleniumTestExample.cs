using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace Nunit.Selenium.Test
{

	[TestFixture()]
	public class SeleniumTestExample
	{

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			if (driver != null)
			{
				//If the test did not pass, take a screenshot
				if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success )
				{
					string currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
					currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("\\")+1);
					((ITakesScreenshot)driver).GetScreenshot().SaveAsFile($"{currentDirectory}Seleniumfailure.png", ScreenshotImageFormat.Png);
				}
				driver.Quit();
			}

		}

		static RemoteWebDriver driver = null;

		[Test()]
		[Ignore("Don't run in CI")]

		public void OpenPageAndCheckUseragentString()
		{

			var options = new InternetExplorerOptions()
			{
				InitialBrowserUrl = "http://www.f15ijp.com/misc/ua.php",
				IntroduceInstabilityByIgnoringProtectedModeSettings = true,
				IgnoreZoomLevel = true,
				EnableNativeEvents = false,
				UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss
			};

			IWebDriver driver = new InternetExplorerDriver(options);

			try
			{

				By locator = By.Id("useragent");

				//Open URl
				driver.Url = "http://www.f15ijp.com/misc/ua.php";
				//Wait
				WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
				wait.Until(ExpectedConditions.ElementIsVisible(locator));

				//find an element om the page
				IWebElement theElement = driver.FindElement(locator);

				Assert.That(theElement.Text, Contains.Substring("trident").IgnoreCase.Or.Contains("internet").IgnoreCase.And.Contains("explorer").IgnoreCase);
			}
			finally
			{

				driver.Quit();

			}

		}

		public RemoteWebDriver GetIEDriver()
		{
			string hubUrl = System.Configuration.ConfigurationManager.AppSettings["seleniumHub"];
			if (string.IsNullOrEmpty(hubUrl))
			{
				hubUrl = "http://localhost:4444/wd/hub";
			}

			DesiredCapabilities browserCapabilites = DesiredCapabilities.InternetExplorer();
			browserCapabilites.SetCapability("ignoreProtectedModeSettings", true);
			browserCapabilites.SetCapability("ie.forceCreateProcessApi", true);
			browserCapabilites.SetCapability("ie.browserCommandLineSwitches", "-private");

			return new RemoteWebDriver(new Uri(hubUrl), browserCapabilites);
		}

		[Test()]
		public void SeleniumGrid()
		{			

				driver = GetIEDriver();

				By locator = By.Id("useragent");
				
				driver.Url = "http://www.f15ijp.com/misc/ua.php";

				WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
				wait.Until(ExpectedConditions.ElementIsVisible(locator));


				IWebElement theElement = driver.FindElement(locator);

				if (driver.Capabilities.BrowserName.Equals("internet explorer"))
				{
					Assert.That(theElement.Text, Contains.Substring("trident").IgnoreCase.Or.Contains("internet").IgnoreCase.And.Contains("explorer").IgnoreCase);
				}
				else if (driver.Capabilities.BrowserName.Equals("opera"))
				{
					Assert.That(theElement.Text, Contains.Substring("OPR/").IgnoreCase);
				}
				else
				{
					Assert.That(theElement.Text, Contains.Substring(driver.Capabilities.BrowserName).IgnoreCase);
				}
				
		}

	}
}
