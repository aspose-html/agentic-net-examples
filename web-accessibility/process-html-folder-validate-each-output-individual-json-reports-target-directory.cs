// Process a folder of HTML files, validate each, and output individual JSON reports to a target directory.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "ValidationReports";

            // Ensure input folder exists and contains at least one sample file
            Directory.CreateDirectory(inputFolder);
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
            }

            // Prepare output directory
            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                bool isValid = false;
                string errorMessage = null;

                try
                {
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // If loading succeeds, consider the HTML valid
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    isValid = false;
                    errorMessage = ex.Message;
                }

                var report = new
                {
                    File = Path.GetFileName(htmlPath),
                    IsValid = isValid,
                    Error = errorMessage
                };

                string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}