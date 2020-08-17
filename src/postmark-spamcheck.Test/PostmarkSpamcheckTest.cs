using Moq;
using Moq.Protected;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace postmarkspamcheck.Test
{
    [TestClass]
    public class PostmarkSpamcheckTest
    {
        [TestMethod]
        public async Task TestGetScoreMakesAPostRequestWithTheCorrectBody()
        {
            var messageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ ""success"": true, ""score"": ""7.9"" }"),
            };
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(messageHandler.Object);
            var ps = new PostmarkSpamcheck(httpClient);

            var result = await ps.GetScore("body");

            messageHandler.Protected()
              .Verify("SendAsync",
                      Times.Exactly(1),
                      ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
                      ItExpr.IsAny<CancellationToken>());

        }

        [TestMethod]
        public async Task TestGetScoreReturnsASpamCheckResult()
        {
            var messageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ ""success"": true, ""score"": ""7.9"" }"),
            };
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(messageHandler.Object);
            var ps = new PostmarkSpamcheck(httpClient);

            var result = await ps.GetScore("body");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SpamcheckResult));
            Assert.IsTrue(result.success);
            Assert.AreEqual("7.9", result.score);
        }

        [TestMethod]
        public async Task TestGetReportMakesAPostRequestWithTheCorrectBody()
        {
            var messageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ ""success"": true, ""score"": ""7.9"", ""rules"": [{""score"": ""1.2"", ""description"": ""test rule""}], ""report"": ""test report"" }"),
            };
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(messageHandler.Object);
            var ps = new PostmarkSpamcheck(httpClient);

            var result = await ps.GetReport("body");

            messageHandler.Protected()
              .Verify("SendAsync",
                      Times.Exactly(1),
                      ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
                      ItExpr.IsAny<CancellationToken>());
        }

        [TestMethod]
        public async Task TestGetReportReturnsASpamCheckResult()
        {
            var messageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ ""success"": true, ""score"": ""7.9"", ""rules"": [{""score"": ""1.2"", ""description"": ""test rule""}], ""report"": ""test report"" }"),
            };
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(messageHandler.Object);
            var ps = new PostmarkSpamcheck(httpClient);

            var result = await ps.GetReport("body");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SpamcheckResult));
            Assert.IsTrue(result.success);
            Assert.AreEqual("7.9", result.score);
            Assert.AreEqual(1, result.rules.Length);
            Assert.AreEqual("1.2", result.rules[0].score);
            Assert.AreEqual("test rule", result.rules[0].description);
            Assert.AreEqual("test report", result.report);
        }
    }
}
