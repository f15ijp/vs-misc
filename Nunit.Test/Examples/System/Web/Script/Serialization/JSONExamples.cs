using NUnit.Framework;
using System.Web.Script.Serialization;

namespace Examples.System.Web.Script.Serialization
{
	[TestFixture]
	class JSONExamples
	{
		[Test]
		public void ParseJSonToDynamicObject()
		{
			string json = @"{
				'Email': 'f15ijp@example.com',
				'CreatedDate': '2013-01-20T00:00:00Z',
				'AnArray': [
					{'value1':'1','value2':'2'}
				]}";

			JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
			dynamic dobj = jsonSerializer.Deserialize<dynamic>(json);
			Assert.Multiple(() =>
			{
				Assert.That(dobj["Email"].ToString(), Is.Not.Empty);
				Assert.That(dobj["AnArray"][0]["value1"], Is.Not.Empty);
			});
			
		}
	}
}
