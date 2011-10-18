using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace postmarkspamcheck
{
	public class PostmarkSpamcheck : IPostmarkSpamcheck
	{
		private readonly IPostmarkSpamcheckWebClient postmarkSpamCheckWebClient;
		
		public PostmarkSpamcheck(IPostmarkSpamcheckWebClient postmarkSpamCheckWebClient)
		{
			this.postmarkSpamCheckWebClient = postmarkSpamCheckWebClient;	
		}
		
		public PostmarkSpamcheck() : this(new PostmarkSpamcheckWebClient())
		{
			
		}
			
		public SpamcheckResult GetScore(string emailBody)
		{
			var spamCheckRequest = new SpamcheckScoreRequest { email = emailBody, options = "short" };
			var jsonResult = this.postmarkSpamCheckWebClient.GetSpamcheckResult(spamCheckRequest);
			return JsonConvert.DeserializeObject<SpamcheckResult>(jsonResult);
		}
		
		public SpamcheckResult GetReport(string emailBody)
		{
			var spamCheckRequest = new SpamcheckScoreRequest { email = emailBody, options = "long" };
			var jsonResult = this.postmarkSpamCheckWebClient.GetSpamcheckResult(spamCheckRequest);
			return JsonConvert.DeserializeObject<SpamcheckResult>(jsonResult);
		}
	}
}

