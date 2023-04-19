using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ImageGen.OpenAI
{
	internal class OpenAIResponseBody
	{
		public OpenAIResponseBody() { }

		[JsonPropertyName("created")]
		public string CreatedStr { get; set; }

		[JsonPropertyName("data")]
		public List<ResponseDataItem> Data { get; set; }
	}

	internal class ResponseDataItem
	{
		public ResponseDataItem() { }

		[JsonPropertyName("url")]
		public string Url { get; set; }
	}
}
