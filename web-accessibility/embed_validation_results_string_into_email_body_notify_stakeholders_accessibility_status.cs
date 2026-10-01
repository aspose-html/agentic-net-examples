// Embed validation results string into an email body to notify stakeholders of accessibility status.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file with an element that will fail accessibility validation
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Test</title></head>
<body>
    <img src='image.png'>
    <a href='https://example.com'>Link</a>
</body>
</html>";
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Create WebAccessibility instance and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    // Example: retrieve the "src" attribute if present
                                    string attributeValue = element.GetAttribute("src") ?? element.GetAttribute("href") ?? string.Empty;
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation successfully.");
                }
            }

            // Clean up temporary file
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