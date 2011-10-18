using System;
using Newtonsoft.Json;

namespace postmarkspamcheck
{
	public class PostmarkSpamcheckWebClient : IPostmarkSpamcheckWebClient
	{
		private readonly IHttpClient httpClient;
		
		public const string PostmarkSpamcheckUrl = "http://spamcheck.postmarkapp.com/filter";
		
		public PostmarkSpamcheckWebClient(IHttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		
		public PostmarkSpamcheckWebClient() : this(new HttpClient())
		{
			
		}
		
		public string GetSpamcheckResult(SpamcheckScoreRequest request)
		{
			var postBody = JsonConvert.SerializeObject(request);
			var response = this.httpClient.Post(PostmarkSpamcheckUrl, postBody, "application/json", 
				"application/json");
			return response.Body;	
		}
	}
}

