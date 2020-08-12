using System;
using System.Threading.Tasks;

namespace postmarkspamcheck
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the raw dump of your email:");
            var email = Console.ReadLine();
            var spamChecker = new PostmarkSpamcheck();
            var score = await spamChecker.GetScore(email);
            if (score.success)
            {
                Console.WriteLine("Score: {0}", score.score);
            }
            else
            {
                Console.WriteLine("Failed: {0}", score.message);
            }
            var report = await spamChecker.GetReport(email);
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
