using ImageGen;
using ImageGen.Generator;
using System.Text.Json;

namespace UnitTests
{
	[TestClass]
	public class PromptGeneratorTests
	{
		string mockJson = @"
							{
							  ""mains"": [
							    ""an equine creature""
							  ],
							  ""styles"": [
							    ""in the artistic style of H. R. Giger""
							  ],
							  ""modifications"": [
							    ""but every animal in the picture has flowers for eyes""
							  ]
							}
							";

		[TestMethod]
		public void PromptGeneratorShouldInitalise()
		{
			try
			{
				var p = new PromptGenerator(mockJson);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void PromptGeneratorShouldFailOnBadJson()
		{
			Assert.ThrowsException<JsonException>(() =>
			{
				var p = new PromptGenerator("this is an invalid json string");
			});
		}

		[TestMethod]
		public void PromptGeneratorShouldFailOnEmptyJson()
		{
			Assert.ThrowsException<JsonException>(() =>
			{
				var p = new PromptGenerator("this is an invalid json string");
			}, Constants.ErrorMessages.NoJsonData);
		}

		[TestMethod]
		public void PromptShouldGenerateCorrectly()
		{
			var p = new PromptGenerator(mockJson);
			
			string expected = "an equine creature, in the artistic style of H. R. Giger, but every animal in the picture has flowers for eyes";
			string generated = p.GeneratePrompt();

			Assert.AreEqual(expected, generated);
		}
	}
}