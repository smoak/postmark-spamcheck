using System;
using System.Net;
using System.IO;

namespace postmarkspamcheck
{
	internal class HttpClient : IHttpClient
	{
		public IHttpResponse Post(string uri, string postBody, 
			string accept = null, string contentType = null)
		{
			var request = (HttpWebRequest)WebRequest.Create(uri);
			if (!string.IsNullOrEmpty(accept))
			{
				request.Accept = accept;
			}
			
			if (!string.IsNullOrEmpty(contentType))
			{
				request.ContentType = contentType;	
			}
			
			request.Method = "POST";
			using (var writer = new StreamWriter(request.GetRequestStream()))
			{
				writer.Write(postBody);
			}
			
			return new HttpResponse(request.GetResponse());
		}
	}
}

