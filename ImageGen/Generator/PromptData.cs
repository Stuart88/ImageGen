using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ImageGen.Generator
{
	internal class PromptData
	{
		public PromptData() {}

		[JsonPropertyName("mains")]
		public List<string> Mains { get; set; }
		
		[JsonPropertyName("styles")]
		public List<string> Styles { get; set; }

		[JsonPropertyName("modifications")]
		public List<string> Modifications { get; set; }

		[JsonIgnore]
		private Random _random = new Random();

		internal PromptDataItem GetRandomData()
		{
			return new PromptDataItem
			(
				main: Mains[_random.Next(Mains.Count)],
				style: Styles[_random.Next(Styles.Count)],
				modification: Modifications[_random.Next(Modifications.Count)]
			);
		}
	}

	internal class PromptDataItem
	{
		internal PromptDataItem(string main, string style, string modification)
		{
			Main = main;
			Style = style;
			Modification = modification;
		}

		internal string Main { get; set; }
		internal string Style { get; set; }
		internal string Modification { get; set; }
	}
}
