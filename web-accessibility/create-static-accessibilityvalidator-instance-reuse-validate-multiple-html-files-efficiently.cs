// Create a static AccessibilityValidator instance and reuse it to validate multiple HTML files efficiently.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    private static readonly AccessibilityValidator validator = new WebAccessibility().CreateValidator(ValidationBuilder.All);

    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "HTMLSamples");
            Directory.CreateDirectory(inputDir);

            string file1 = Path.Combine(inputDir, "sample1.html");
            string file2 = Path.Combine(inputDir, "sample2.html");

            File.WriteAllText(file1, "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>Test 1</h1></body></html>");
            File.WriteAllText(file2, "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><img src=\"missing.jpg\" alt=\"\"/></body></html>");

            List<string> htmlFiles = new List<string> { file1, file2 };

            int index = 1;
            foreach (string htmlPath in htmlFiles)
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ValidationResult validationResult = validator.Validate(document);
                    if (validationResult.Success)
                    {
                        Console.WriteLine($"File {index}: Validation succeeded.");
                    }
                    else
                    {
                        Console.WriteLine($"File {index}: Validation failed with the following errors:");
                        foreach (RuleValidationResult ruleResult in validationResult.Details)
                        {
                            if (!ruleResult.Success)
                            {
                                foreach (ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}