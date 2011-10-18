using System;

namespace postmarkspamcheck
{
	public class SpamcheckResult
	{
		public bool Success { get;set; }
		public string Score { get;set; }
		public string Message { get;set; }
		public string Report { get;set; }
	}
}

