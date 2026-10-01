// Re‑run validation after HTML modifications to confirm that previously reported issues are resolved.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Welcome</h1>
    <img src='missing.jpg' alt=''>
    <a href=''>Empty link</a>
</body>
</html>";

            // Write content to a temporary file
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath);

            // Create WebAccessibility instance and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description}");
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            Aspose.Html.Accessibility.IError error = techResult.Error;
                            Console.WriteLine($"  Error: {error.ErrorMessage}");
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
                Console.WriteLine("Accessibility validation succeeded with no errors.");
            }

            // Clean up temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}