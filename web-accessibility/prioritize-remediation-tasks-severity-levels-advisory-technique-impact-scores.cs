// Prioritize remediation tasks based on severity levels and advisory technique impact scores.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with remediation tasks
            string htmlContent = @"
                <html>
                <body>
                    <div class='task' data-name='Update library' data-severity='High' data-score='75'>Task 1</div>
                    <div class='task' data-name='Patch vulnerability' data-severity='Critical' data-score='90'>Task 2</div>
                    <div class='task' data-name='Refactor code' data-severity='Medium' data-score='60'>Task 3</div>
                    <div class='task' data-name='Improve logging' data-severity='Low' data-score='40'>Task 4</div>
                </body>
                </html>";

            // Write HTML to a temporary file
            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Load the HTML document from the temporary file
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath, configuration))
            {
                // Select all task elements
                Aspose.Html.Collections.NodeList taskNodes = document.QuerySelectorAll(".task");

                List<RemediationTask> tasks = new List<RemediationTask>();

                foreach (Element element in taskNodes)
                {
                    string name = element.GetAttribute("data-name");
                    string severityStr = element.GetAttribute("data-severity");
                    string scoreStr = element.GetAttribute("data-score");

                    if (Enum.TryParse(severityStr, true, out Severity severity) && int.TryParse(scoreStr, out int score))
                    {
                        tasks.Add(new RemediationTask
                        {
                            Name = name,
                            Severity = severity,
                            ImpactScore = score
                        });
                    }
                }

                // Prioritize tasks: higher severity first, then higher impact score
                tasks.Sort((a, b) =>
                {
                    int severityComparison = GetSeverityRank(b.Severity).CompareTo(GetSeverityRank(a.Severity));
                    if (severityComparison != 0) return severityComparison;
                    return b.ImpactScore.CompareTo(a.ImpactScore);
                });

                Console.WriteLine("Prioritized Remediation Tasks:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.Name} - Severity: {task.Severity}, Impact Score: {task.ImpactScore}");
                }
            }

            // Clean up temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int GetSeverityRank(Severity severity)
    {
        switch (severity)
        {
            case Severity.Critical: return 4;
            case Severity.High: return 3;
            case Severity.Medium: return 2;
            case Severity.Low: return 1;
            default: return 0;
        }
    }
}

enum Severity
{
    Low,
    Medium,
    High,
    Critical
}

class RemediationTask
{
    public string Name { get; set; }
    public Severity Severity { get; set; }
    public int ImpactScore { get; set; }
}