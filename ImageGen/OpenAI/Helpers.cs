using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ImageGen.OpenAI.OpenAiConstants;

namespace ImageGen.OpenAI
{
	internal static class Helpers
	{
		internal static int GetNValue(NumberEnum n)
		{
			return (int)n;
		}

		internal static string GetSize(SizeEnum s)
		{
			return s switch
			{
				SizeEnum._256 => Size._256,
				SizeEnum._512 => Size._512,
				SizeEnum._1024 => Size._1024,
				_ => throw new NotSupportedException()
			};
		}

		internal static string GetResponseFormat(ResponseFormatEnum r)
		{
			return r switch
			{
				ResponseFormatEnum.Url => ResponseFormat.Url,
				ResponseFormatEnum.Base64Json => ResponseFormat.Base64Jon,
				_ => throw new NotSupportedException()
			};
		}
	}
}
