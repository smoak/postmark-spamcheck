using System;
using System.Threading.Tasks;

namespace postmarkspamcheck
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter the raw dump of your email:");
      var email = Console.ReadLine();
      var spamChecker = new PostmarkSpamcheck();
      var scoreTask = spamChecker.GetScore(email);
      scoreTask.Wait();
      var score = scoreTask.Result;
      if (score.success)
      {
        Console.WriteLine("Score: {0}", score.score);
      }
      else
      {
        Console.WriteLine("Failed: {0}", score.message);
      }
      var reportTask = spamChecker.GetReport(email);
      reportTask.Wait();
      var report = reportTask.Result;
      if (report.success)
      {
        Console.WriteLine("Score: {0}\nReport: {1}", report.score, report.report);
      }
      else
      {
        Console.WriteLine("Failed: {0}", report.message);
      }
    }
  }
}
