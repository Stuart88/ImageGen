using ImageGen.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGen.OpenAI
{
	public class ImageFetcher
	{
		private const string _openApiKey = "";
		private const string _openAiBaseUrl = @"https://api.openai.com/v1/images/generations";

		public event EventHandler OnFetchStarted;
		public event EventHandler OnFetchFinished;
		public event EventHandler<OpenAIFetchErrorEventArgs> OnError;

		public ImageFetcher() { }

		/// <summary>
		/// Gets a PNG image from the OpenAI using a custom prompt, or a random generated prompt. 
		/// Image returned as byte array.
		/// </summary>
		/// <param name="customPrompt"></param>
		/// <returns></returns>
		public async Task<byte[]> FetchImageBytes(string? customPrompt = null)
		{
			try
			{
				OnFetchStarted?.Invoke(this, EventArgs.Empty);

				string result = await GetImageFromOpenAI(customPrompt);

				if (string.IsNullOrEmpty(result))
					throw new Exception("OpenAI fetch succeeded but image was empty!");

				return Convert.FromBase64String(result);
			}
			catch(Exception ex)
			{
				OnError?.Invoke(this, new OpenAIFetchErrorEventArgs(ex));

				return new byte[] { };
			}
			finally
			{
				OnFetchFinished?.Invoke(this, EventArgs.Empty);
			}
		}

		private async Task<string> GetImageFromOpenAI(string? customPrompt = null)
		{
			using HttpClient httpClient = new HttpClient()
			{
				Timeout = TimeSpan.FromSeconds(60)
			};

			var requestBody = CreateRequestBody(customPrompt);

			StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody));
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
			httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", $"Bearer {_openApiKey}");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); 

			var response = await httpClient.PostAsync(_openAiBaseUrl, content);

			if (!response.IsSuccessStatusCode)
			{
				throw new Exception(response.ReasonPhrase);
			}

			string responseContent = await response.Content.ReadAsStringAsync();

			var responseData = System.Text.Json.JsonSerializer.Deserialize<OpenAIResponseBody>(responseContent);

			return responseData.Data.FirstOrDefault().Url;
		}

		/// <summary>
		/// Creates a request body for submitting to OpenAI image generator
		/// </summary>
		/// <param name="customPrompt">Use this if provided, otherwise generates random prompt</param>
		/// <returns></returns>
		private OpenAIRequestBody CreateRequestBody(string? customPrompt)
		{
			if (customPrompt != null)
				return new OpenAIRequestBody(customPrompt);

			string dataPath = Path.Combine(System.Environment.CurrentDirectory, "prompts.json");
			string json = File.ReadAllText(dataPath);

			PromptGenerator generator = new PromptGenerator(json);

			return new OpenAIRequestBody(generator.GeneratePrompt());
		}
	}
}
