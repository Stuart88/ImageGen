using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static ImageGen.OpenAI.OpenAiConstants;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ImageGen.OpenAI
{
	internal class OpenAIRequestBody
	{
		/// <param name="prompt">A text description of the desired image(s). The maximum length is 1000 characters.</param>
		/// <param name="n">The number of images to generate. Must be between 1 and 10.</param>
		/// <param name="size">The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.</param>
		/// <param name="responseFormat">The format in which the generated images are returned. Must be one of url or b64_json.</param>
		/// <param name="user">A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse</param>
		public OpenAIRequestBody(string prompt, 
			NumberEnum n = NumberEnum._1,
			SizeEnum size = SizeEnum._1024,
			ResponseFormatEnum responseFormat = ResponseFormatEnum.Url, 
			string? user = null)
		{
			Prompt = prompt;
			N = Helpers.GetNValue(n);
			Size = Helpers.GetSize(size);
			ResponseFormat = Helpers.GetResponseFormat(responseFormat);
			User = user;
		}

		[JsonPropertyName("prompt")]
		public string Prompt { get; private set; }
		
		[JsonPropertyName("n")]
		public int N { get; private set; }
		
		[JsonPropertyName("size")]
		public string Size { get; private set; }
		
		[JsonPropertyName("response_format")]
		public string ResponseFormat { get; private set; }
		
		[JsonPropertyName("user")]
		public string? User { get; private set; }
	}
}
