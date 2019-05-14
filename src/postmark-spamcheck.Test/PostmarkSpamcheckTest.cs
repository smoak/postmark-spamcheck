using Microsoft.VisualStudio.TestTools.UnitTesting;
using postmarkspamcheck;

namespace postmarkspamcheck.Test
{
  [TestClass]
  public class PostmarkSpamcheckTest
  {
    [TestMethod]
    public void TestGetScoreMakesAPostRequestWithTheCorrectBody()
    {
      var ps = new PostmarkSpamcheck();

      var task = ps.GetScore("body");
      task.Wait();
      var result = task.Result;

    }
  }
}
