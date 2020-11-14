using System;
using System.Web;
using NUnit.Framework;

namespace NUnit.dotnet35.Tests.Examples.System {
	public class UriExamples {
		[Test]
		public void UriProperties() {
			var uriBuilder = new UriBuilder("https://www.example.com:443/somepath") {
				Query = "somekey=" + HttpUtility.UrlEncode("some+value&test")
			};

			var uri = uriBuilder.Uri;

			TestContext.WriteLine($"AbsoluteUri {uri.AbsoluteUri}{Environment.NewLine}" +
								  $"ToString {uri.ToString()}{Environment.NewLine}" +
								  $"Scheme {uri.Scheme}{Environment.NewLine}" +
								  $"Host {uri.Host}{Environment.NewLine}" +
								  $"Post {uri.Port}{Environment.NewLine}" +
								  $"OriginalString {uri.OriginalString}{Environment.NewLine}" +
								  $"GetLeftPart(UriPartial.Authority) {uri.GetLeftPart(UriPartial.Authority)}{Environment.NewLine}" +
								  $"GetLeftPart(UriPartial.Path) {uri.GetLeftPart(UriPartial.Path)}{Environment.NewLine}" +
								  $"GetLeftPart(UriPartial.Query) {uri.GetLeftPart(UriPartial.Query)}{Environment.NewLine}" +
								  $"GetLeftPart(UriPartial.Scheme) {uri.GetLeftPart(UriPartial.Scheme)}{Environment.NewLine}" +
								  $"");
		}
	}
}
