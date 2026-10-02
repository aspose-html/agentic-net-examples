// Develop a command‑line tool accepting input path and output format arguments to perform validation on demand.

using System;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Determine input HTML file path
            string inputPath = args.Length > 0 ? args[0] : "sample.html";

            // Ensure the input file exists; create a minimal sample if needed
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            // Determine output format (xml or json), default to xml
            string formatArg = args.Length > 1 ? args[1].ToLowerInvariant() : "xml";
            ValidationResultSaveFormat saveFormat = formatArg == "json"
                ? ValidationResultSaveFormat.JSON
                : ValidationResultSaveFormat.XML;

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Create the accessibility validator
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                ValidationResult result = validator.Validate(document);

                // Output validation result
                using (StringWriter sw = new StringWriter())
                {
                    result.SaveTo(sw, saveFormat);
                    Console.WriteLine(sw.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}