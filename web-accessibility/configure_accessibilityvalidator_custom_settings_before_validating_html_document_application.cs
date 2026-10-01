// Configure an AccessibilityValidator with custom settings before validating an HTML document in the application.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1 id='header'>Hello World</h1>
    <img src='image.png' alt='Sample Image' />
</body>
</html>";
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent, Encoding.UTF8);

            // Initialize WebAccessibility and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation succeeded. No issues found.");
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
                                // Print the error message
                                Console.WriteLine($"Error: {techResult.Error.ErrorMessage}");

                                // If the target is an HTML element, print additional info
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string idAttribute = element.GetAttribute("id");
                                    Console.WriteLine($"  Element: <{tagName}> Id: {idAttribute}");
                                }
                            }
                        }
                    }
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
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}