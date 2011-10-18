### Usage

Create an instance of the PostmarkSpamcheck class:

`var spamChecker = new PostmarkSpamcheck();`

Then pass the email to be checked:

`var spamResults = spamChecker.GetScore("The raw email body");`
`var spamReport = spamChecker.GetReport("The raw email body");`

Then you can access the score or report:

`Console.WriteLine("Score: {0}", spamResults.Score);`
`Console.WriteLine("Report: {0}", spamReport.Report);`

### Sample Usage

    var email = Console.ReadLine();
    var spamChecker = new PostmarkSpamcheckmarkSpamcheck();
    var score = spamChecker.GetScore(email);
    if (score.Success) {
        Console.WriteLine("Score: {0}", score.Score);
    } else {
        Console.WriteLine("Failed: {0}", score.Message);
    }
    var report = spamChecker.GetReport(email);
    if (report.Success) {
        Console.WriteLine("Score: {0}\nReport: {1}", report.Score, reportport.Report);
    } else {
        Console.WriteLine("Failed: {0}", reporteport.Message);
    }
