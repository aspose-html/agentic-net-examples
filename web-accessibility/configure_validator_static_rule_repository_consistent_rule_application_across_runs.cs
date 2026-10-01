// Configure the validator to use a static rule repository for consistent rule application across runs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML content and save it to a temporary file
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample Page</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This is a sample HTML document for accessibility validation.</p>
</body>
</html>";

            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Initialize WebAccessibility and create a validator for all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (!validationResult.Success)
            {
                Console.WriteLine("Accessibility validation failed. Details:");
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    string ruleCode = detail.Rule?.Code ?? "N/A";
                    string ruleDescription = detail.Rule?.Description ?? "No description";
                    Console.WriteLine($"Rule: {ruleCode}");
                    Console.WriteLine($"Description: {ruleDescription}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            else
            {
                Console.WriteLine("Accessibility validation succeeded. No issues found.");
            }

            // Clean up
            document.Dispose();
            // Optionally delete the temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}