// Compare two ValidationResult objects to detect regressions after modifying HTML content in the same project.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1><img src='image.png'></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            // Initialize accessibility validator
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            var document = new Aspose.Html.HTMLDocument(tempFile);
            var validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                foreach (var ruleResult in validationResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        Console.WriteLine($"{ruleResult.Rule.Code}: {ruleResult.Rule.Description}");
                        foreach (var techResult in ruleResult.Errors)
                        {
                            var error = techResult.Error;
                            Console.WriteLine(error.ErrorMessage);
                            if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                var element = (Aspose.Html.HTMLElement)error.Target.Item;
                                Console.WriteLine(element.OuterHTML);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Document passed accessibility validation.");
            }

            // Clean up temporary file
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}