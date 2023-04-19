using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGen.OpenAI
{
	public class OpenAIFetchErrorEventArgs : EventArgs
	{
		public OpenAIFetchErrorEventArgs(Exception e)
		{
			this.Exception = e;
		}

		public Exception Exception { get; set; }
	}
}
