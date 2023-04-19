using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ImageGen
{
	internal static class Constants
	{
		internal static class ErrorMessages
		{
			internal const string NoJsonData = "No Json data found";
		}
	}
}
