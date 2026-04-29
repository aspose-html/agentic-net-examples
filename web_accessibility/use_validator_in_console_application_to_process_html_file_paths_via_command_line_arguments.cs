// Use the validator in a console application to process a list of HTML file paths via command‑line arguments.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide HTML file paths as arguments.");
                return;
            }

            // Create a validator with default accessibility rules
            var webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator();

            foreach (var filePath in args)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    continue;
                }

                // Load the HTML document
                using (var document = new HTMLDocument(filePath))
                {
                    // Perform validation
                    ValidationResult result = validator.Validate(document);

                    // Output validation summary
                    Console.WriteLine($"Validation result for \"{filePath}\": {(result.Success ? "Success" : "Failed")}");

                    // Output detailed validation information
                    Console.WriteLine(result.SaveToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}