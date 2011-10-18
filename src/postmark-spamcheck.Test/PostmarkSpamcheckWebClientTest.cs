using System;

using NUnit.Framework;
using Rhino.Mocks;

namespace postmarkspamcheck.Test
{
	[TestFixture]
	public class PostmarkSpamcheckWebClientTest
	{
		[Test]
		public void GetSpamcheckResult_should_use_http_client_to_POST()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockWebClient.Expect(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockWebClient.AssertWasCalled(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything));
		}
		
		[Test]
		public void GetSpamcheckResult_should_get_response_body_from_http_client()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockResponse.Stub(a => a.Body).Return("stuff");
			mockWebClient.Stub(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockResponse.AssertWasCalled(a => a.Body);
		}
		
		[Test]
		public void GetSpamcheckResult_should_use_http_client_to_POST_with_correct_url()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockWebClient.Stub(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockWebClient.AssertWasCalled(a => 
				a.Post(Arg<string>.Is.Equal(PostmarkSpamcheckWebClient.PostmarkSpamcheckUrl), 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything));
		}
		
		[Test]
		public void GetSpamcheckResult_should_use_http_client_to_POST_with_correct_accept_header()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockWebClient.Stub(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockWebClient.AssertWasCalled(a => 
				a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Equal("application/json"),  
				Arg<string>.Is.Anything));
		}
		
		[Test]
		public void GetSpamcheckResult_should_use_http_client_to_POST_with_correct_content_type_header()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockWebClient.Stub(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockWebClient.AssertWasCalled(a => 
				a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, 
				Arg<string>.Is.Equal("application/json")));
		}
		
		[Test]
		public void GetSpamcheckResult_should_use_http_client_to_POST_with_correct_post_body()
		{
			// Arrange
			var mockWebClient = MockRepository.GenerateMock<IHttpClient>();
			var postmarkSpamcheckWebClient = new PostmarkSpamcheckWebClient(mockWebClient);
			var spamCheckRequest = new SpamcheckScoreRequest { email = "test", options = "short" };
			var mockResponse = MockRepository.GenerateMock<IHttpResponse>();
			mockWebClient.Stub(a => a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(mockResponse);
			
			// Act
			postmarkSpamcheckWebClient.GetSpamcheckResult(spamCheckRequest);
			
			// Assert
			mockWebClient.AssertWasCalled(a => 
				a.Post(Arg<string>.Is.Anything, 
				Arg<string>.Is.Equal("{\"email\":\"test\",\"options\":\"short\"}"),
				Arg<string>.Is.Anything, 
				Arg<string>.Is.Anything));
		}
	}
}

