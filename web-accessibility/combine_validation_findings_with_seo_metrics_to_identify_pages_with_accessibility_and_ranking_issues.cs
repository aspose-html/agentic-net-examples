// Combine validation findings with SEO metrics to identify pages with both accessibility and ranking issues.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal sample HTML file
            string samplePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head>" +
                    "<body><img src='image.png' alt='Sample image'></body></html>");
            }

            // List of URLs (using the local file path for simplicity)
            List<string> urls = new List<string> { samplePath, samplePath };

            // Output directory for validation results
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "ValidationResults");
            Directory.CreateDirectory(outputDir);

            // Initialize WebAccessibility and a validator that checks all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator =
                webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    // Save the validation result as XML
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());

                    // Output detailed errors to the console
                    if (!validationResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                        {
                            if (!ruleResult.Success)
                            {
                                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    Aspose.Html.Accessibility.IError error = techResult.Error;
                                    if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                    {
                                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                        string tagName = element.TagName;
                                        string altValue = element.GetAttribute("alt");
                                        Console.WriteLine($"Tag: {tagName}, Attribute (alt): {altValue}, Message: {error.ErrorMessage}");
                                    }
                                    else
                                    {
                                        Console.WriteLine(error.ErrorMessage);
                                    }
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