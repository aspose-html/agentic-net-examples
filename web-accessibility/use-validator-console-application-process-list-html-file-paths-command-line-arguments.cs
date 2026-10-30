// Use the validator in a console application to process a list of HTML file paths via command‑line arguments.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<string> files = new List<string>();

            if (args != null && args.Length > 0)
            {
                files.AddRange(args);
            }
            else
            {
                const string defaultFile = "sample.html";
                if (!File.Exists(defaultFile))
                {
                    File.WriteAllText(defaultFile, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
                }
                files.Add(defaultFile);
            }

            foreach (string path in files)
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine($"File not found: {path}");
                    continue;
                }

                // Load the HTML document from file
                HTMLDocument document = new HTMLDocument(path);

                // Create the accessibility validator with default rule set
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult result = validator.Validate(document);

                // Output validation summary
                Console.WriteLine($"Validation result for '{path}': Success = {result.Success}");
                Console.WriteLine($"Number of rule results: {result.Details.Count}");

                // Optionally, list each rule result details
                foreach (var ruleResult in result.Details)
                {
                    Console.WriteLine($"- Rule ID: {ruleResult.Rule.Code}, Success: {ruleResult.Success}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}