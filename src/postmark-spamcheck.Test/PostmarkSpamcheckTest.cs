using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

using postmarkspamcheck;

namespace postmarkspamcheck.Test
{
	[TestFixture]
	public class PostmarkSpamcheckTest
	{
		[Test]
		public void GetScore_should_use_PostmarkSpamcheckWebClient_to_get_a_spamcheck_result()
		{
			// Arrange
			var jsonResponse = "{\"success\":true,\"score\":\"7.9/5.0\n\"}";
			var mockPostmarkSpamcheckWebClient = MockRepository.GenerateMock<IPostmarkSpamcheckWebClient>();
			var spamCheck = new PostmarkSpamcheck(mockPostmarkSpamcheckWebClient);
			mockPostmarkSpamcheckWebClient
				.Stub(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything))
					.Return(jsonResponse);
						
			// Act
			spamCheck.GetScore("Email");
			
			//Assert
			mockPostmarkSpamcheckWebClient
				.AssertWasCalled(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything));
		}
		
		[Test]
		public void GetScore_should_deserialize_json_correctly()
		{
			// Arrange
			var jsonResponse = "{\"success\":true,\"score\":\"7.9/5.0\n\"}";
			var mockPostmarkSpamcheckWebClient = MockRepository.GenerateStub<IPostmarkSpamcheckWebClient>();
			var spamCheck = new PostmarkSpamcheck(mockPostmarkSpamcheckWebClient);
			mockPostmarkSpamcheckWebClient
				.Stub(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything))
					.Return(jsonResponse);
			
			
			// Act
			var result = spamCheck.GetScore("Email");
			
			//Assert
			Assert.AreEqual(true, result.Success);
			Assert.AreEqual("7.9/5.0\n", result.Score);
		}
		
		[Test]
		public void GetReport_should_deserialize_json_correctly()
		{
			// Arrange
			var jsonResponse = "{\"success\":true,\"score\":\"7.9/5.0\n\"}";
			var mockPostmarkSpamcheckWebClient = MockRepository.GenerateStub<IPostmarkSpamcheckWebClient>();
			var spamCheck = new PostmarkSpamcheck(mockPostmarkSpamcheckWebClient);
			mockPostmarkSpamcheckWebClient
				.Stub(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything))
					.Return(jsonResponse);
			
			
			// Act
			var result = spamCheck.GetReport("Email");
			
			//Assert
			Assert.AreEqual(true, result.Success);
			Assert.AreEqual("7.9/5.0\n", result.Score);
		}
		
		[Test]
		public void GetReport_should_use_PostmarkSpamcheckWebClient_to_get_a_spamcheck_result()
		{
			// Arrange
			var jsonResponse = "{\"success\":true,\"score\":\"7.9/5.0\n\"}";
			var mockPostmarkSpamcheckWebClient = MockRepository.GenerateMock<IPostmarkSpamcheckWebClient>();
			var spamCheck = new PostmarkSpamcheck(mockPostmarkSpamcheckWebClient);
			mockPostmarkSpamcheckWebClient
				.Stub(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything))
					.Return(jsonResponse);
						
			// Act
			spamCheck.GetReport("Email");
			
			//Assert
			mockPostmarkSpamcheckWebClient
				.AssertWasCalled(a => a.GetSpamcheckResult(Arg<SpamcheckScoreRequest>.Is.Anything));
		}
	}
}

