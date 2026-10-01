// Generate a plain‑text summary of validation findings for quick review by developers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Test</title></head>
<body>
    <img src='image.jpg' alt=''>
    <a href=''>Empty link</a>
</body>
</html>";

            // Write the sample HTML to a temporary file
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Create WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            Console.WriteLine($"Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine($"  Message: {error.ErrorMessage}");

                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine($"  Element HTML: {element.OuterHTML}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }

            // Clean up temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}