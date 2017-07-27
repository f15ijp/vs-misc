using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace Nunit.Selenium.Test
{

	[TestFixture()]
	public class SeleniumTestExample
	{

		[Test()]

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

	}
}
