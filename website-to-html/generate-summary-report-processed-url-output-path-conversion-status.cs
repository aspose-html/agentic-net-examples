// Generate a summary report listing each processed URL, output path, and conversion status.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define input URLs
            string[] urls = new string[]
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            // Prepare output directory and CSV report path
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string csvPath = "summary.csv";

            // List to hold report entries
            List<ReportEntry> report = new List<ReportEntry>();

            // Process each URL
            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                string outputPath = Path.Combine(outputDirectory, $"page{i + 1}.html");
                try
                {
                    // Load HTML document from URL
                    HTMLDocument document = new HTMLDocument(url);
                    // Save document to local file
                    document.Save(outputPath);
                    // Record success
                    report.Add(new ReportEntry { Url = url, OutputPath = outputPath, Status = "Success" });
                }
                catch (Exception ex)
                {
                    // Record failure
                    report.Add(new ReportEntry { Url = url, OutputPath = string.Empty, Status = "Failed: " + ex.Message });
                }
            }

            // Write CSV summary report
            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("URL,OutputPath,Status");
                foreach (ReportEntry entry in report)
                {
                    // Escape commas in fields if necessary
                    string escapedUrl = entry.Url.Contains(",") ? $"\"{entry.Url}\"" : entry.Url;
                    string escapedPath = entry.OutputPath.Contains(",") ? $"\"{entry.OutputPath}\"" : entry.OutputPath;
                    string escapedStatus = entry.Status.Contains(",") ? $"\"{entry.Status}\"" : entry.Status;
                    csvWriter.WriteLine($"{escapedUrl},{escapedPath},{escapedStatus}");
                }
            }

            Console.WriteLine("Processing completed. Summary report saved to " + csvPath);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }

    class ReportEntry
    {
        public string Url { get; set; }
        public string OutputPath { get; set; }
        public string Status { get; set; }
    }
}