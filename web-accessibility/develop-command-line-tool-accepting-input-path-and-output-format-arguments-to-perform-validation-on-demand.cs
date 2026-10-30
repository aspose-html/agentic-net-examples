// Develop a command‑line tool accepting input path and output format arguments to perform validation on demand.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.html";
            string outputPath = args.Length > 1 ? args[1] : "validation_result.xml";

            if (!File.Exists(inputPath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    result.SaveTo(writer, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                }

                Console.WriteLine($"Validation completed. Result saved to \"{outputPath}\".");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}