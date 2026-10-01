// Configure the validator to ignore selected rule codes, allowing custom compliance thresholds during checks.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Write the sample HTML to a temporary file
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(tempFilePath);

            // Create WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create a validator for all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Validate the document
            var validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                Console.WriteLine("Validation failed. Details:");
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                    if (!detail.Success)
                    {
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            var target = techResult.Error.Target;
                            if (target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                var element = (Aspose.Html.HTMLElement)target.Item;
                                Console.WriteLine($"  Element: <{element.TagName}> OuterHTML: {element.OuterHTML}");
                            }
                            else
                            {
                                Console.WriteLine($"  Target type: {target.TargetType}");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Validation succeeded with no errors.");
            }

            // Example: Validate a specific guideline under a principle
            var principle = webAccessibility.Rules.GetPrinciple("WCAG2AA");
            var guideline = principle.GetGuideline("1.1.1"); // Example guideline code
            var validator2 = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
            var validationResult2 = validator2.Validate(document);
            if (!validationResult2.Success)
            {
                Console.WriteLine("Guideline validation failed.");
            }
            else
            {
                Console.WriteLine("Guideline validation succeeded.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}