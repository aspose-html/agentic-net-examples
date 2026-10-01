// Instantiate an AccessibilityValidator using CreateValidator before loading any HTML document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file with an accessibility issue (missing alt attribute on img)
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Accessibility Test</title></head>
<body>
    <img src='image.png'>
</body>
</html>";
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputFilePath, htmlContent);

            // Initialize WebAccessibility and create a validator for all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputFilePath))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
                {
                    Console.WriteLine("Accessibility validation failed. Details:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                // If the error target is an HTML element, output element details
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt"); // example attribute
                                    Console.WriteLine($"Tag: {tagName}, Alt attribute: {attributeValue ?? "null"}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    // Non-element target, just output the message
                                    Console.WriteLine($"Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // Clean up the temporary file
            if (File.Exists(inputFilePath))
            {
                File.Delete(inputFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}