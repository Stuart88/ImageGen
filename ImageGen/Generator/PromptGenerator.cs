using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ImageGen.Generator
{
    internal class PromptGenerator
    {
        private PromptData _promptData;

        internal PromptGenerator(string json)
        {
            _promptData = System.Text.Json.JsonSerializer.Deserialize<PromptData>(json) 
                ?? throw new Exception(Constants.ErrorMessages.NoJsonData);
        }

        internal string GeneratePrompt()
        {
            var p = _promptData.GetRandomData();

            return $"{p.Main}, {p.Style}, {p.Modification}";
        }

	}
}
