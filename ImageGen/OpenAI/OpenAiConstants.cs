using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGen.OpenAI
{
	internal class OpenAiConstants
	{
		internal enum NumberEnum
		{
			_1 = 1,
			_2 = 2,
			_3 = 3,
			_4 = 4,
			_5 = 5,
			_6 = 6,
			_7 = 7,
			_8 = 8,
			_9 = 9,
			_10 = 10
		}

		internal enum SizeEnum
		{
			_256,
			_512,
			_1024
		}

		internal enum ResponseFormatEnum
		{
			Url,
			Base64Json
		}

		internal static class Size
		{
			internal const string _256 = "256x256";
			internal const string _512 = "512x512";
			internal const string _1024 = "1024x1024";
		}

		internal static class ResponseFormat
		{
			internal const string Url = "url";
			internal const string Base64Jon = "b64_json";
		}
	}
}
