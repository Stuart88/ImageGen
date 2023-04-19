using ImageGen.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestClass]
	public class OpenAiTests
	{
		[TestMethod]
		public void RequestBodyShouldConstructCorrectly()
		{
			OpenAIRequestBody req = new OpenAIRequestBody(
				"prompt text",
				OpenAiConstants.NumberEnum._1,
				OpenAiConstants.SizeEnum._1024,
				OpenAiConstants.ResponseFormatEnum.Url,
				"user_name");

			Assert.AreEqual(req.Prompt, "prompt text");
			Assert.AreEqual(req.N, 1);
			Assert.AreEqual(req.Size, OpenAiConstants.Size._1024);
			Assert.AreEqual(req.ResponseFormat, OpenAiConstants.ResponseFormat.Url);
			Assert.AreEqual(req.User, "user_name");
		}

		[TestMethod]
		public async Task ImageFetcherWillFireOnErrorEvent()
		{
			var fetcher = new ImageFetcher();

			int testVal = 0;

			fetcher.OnError += (s, e) => 
			{
				testVal++;
				Assert.AreEqual("Unauthorized" ,e.Exception.Message);
			};

			await fetcher.FetchImageBytes();

			Assert.IsTrue(testVal == 1);
		}

		[TestMethod]
		public async Task ImageFetcherWillFireFetchStartedEvent()
		{
			var fetcher = new ImageFetcher();

			int testVal = 0;

			fetcher.OnFetchStarted += (s, e) =>
			{
				testVal++;
			};

			await fetcher.FetchImageBytes();

			Assert.IsTrue(testVal == 1);
		}

		[TestMethod]
		public async Task ImageFetcherWillFireFetchFinishedEvent()
		{
			var fetcher = new ImageFetcher();

			int testVal = 0;

			fetcher.OnFetchFinished += (s, e) =>
			{
				testVal++;
			};

			await fetcher.FetchImageBytes();

			Assert.IsTrue(testVal == 1);
		}
	}
}
