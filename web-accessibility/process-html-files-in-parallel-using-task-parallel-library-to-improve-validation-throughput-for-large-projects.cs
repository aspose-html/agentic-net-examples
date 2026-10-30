// Process HTML files in parallel using Task Parallel Library to improve validation throughput for large projects.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "ValidationResults";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello</p></body></html>");
            }

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                try
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        var validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                        Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

                        string resultPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".txt");
                        File.WriteAllText(resultPath, result.SaveToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{htmlPath}': {ex.Message}");
                }
            });

            Console.WriteLine("Validation completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}