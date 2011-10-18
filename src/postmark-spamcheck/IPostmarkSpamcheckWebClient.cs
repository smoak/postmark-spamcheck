using System;

namespace postmarkspamcheck
{
	public interface IPostmarkSpamcheckWebClient
	{
		string GetSpamcheckResult(SpamcheckScoreRequest request);
	}
}

