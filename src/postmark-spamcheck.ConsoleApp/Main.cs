using System;
using postmarkspamcheck;

/// <summary>
/// This is a sample console app to demonstrate how to use
/// the postmarkspamcheck library.
/// </summary>
namespace postmarkspamcheck.ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var email = Console.ReadLine();
			var spamChecker = new PostmarkSpamcheck();
			var score = spamChecker.GetScore(email);
			if (score.Success)
			{
				Console.WriteLine("Score: {0}", score.Score);	
			}
			else
			{
				Console.WriteLine("Failed: {0}", score.Message);	
			}
			var report = spamChecker.GetReport(email);
			if (report.Success)
			{
				Console.WriteLine("Score: {0}\nReport: {1}", report.Score, report.Report);	
			}
			else
			{
				Console.WriteLine("Failed: {0}", report.Message);	
			}
		}
	}
}
