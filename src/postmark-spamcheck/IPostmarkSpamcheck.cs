using System;

namespace postmarkspamcheck
{
	public interface IPostmarkSpamcheck
	{
		SpamcheckResult GetScore(string email);
		SpamcheckResult GetReport(string email);
	}
}

