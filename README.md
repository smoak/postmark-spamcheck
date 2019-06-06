# Postmark Spamcheck

[![Version](https://img.shields.io/nuget/v/PostmarkSpamcheck.svg?style=popout-square)](https://www.nuget.org/packages/PostmarkSpamcheck/)

A c# library to help you query Postmark's [spamcheck api](https://spamcheck.postmarkapp.com/doc/)

### Usage

Add as a dependency

`dotnet add package PostmarkSpamcheck --version 1.0.0`

Create an instance of the PostmarkSpamcheck class:

`var spamChecker = new PostmarkSpamcheck();`

Then pass the email to be checked:

    var spamResults = await spamChecker.GetScore("The raw email body");
    var spamReport = await spamChecker.GetReport("The raw email body");

Then you can access the score or report:

    Console.WriteLine("Score: {0}", spamResults.score);
    Console.WriteLine("Report: {0}", spamReport.report);

### Sample Usage

    var email = Console.ReadLine();
    var spamChecker = new PostmarkSpamcheckmarkSpamcheck();
    var scoreTask = spamChecker.GetScore(email);
    scoreTask.Wait();
    var score = scoreTask.Result;
    if (score.success) {
        Console.WriteLine("Score: {0}", score.score);
    } else {
        Console.WriteLine("Failed: {0}", score.message);
    }
    var reportTask = spamChecker.GetReport(email);
    reportTask.Wait();
    var report = reportTask.Result;
    if (report.success) {
        Console.WriteLine("Score: {0}\nReport: {1}", report.score, reportport.report);
    } else {
        Console.WriteLine("Failed: {0}", reporteport.message);
    }
