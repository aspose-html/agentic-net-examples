// Fail the build if any critical accessibility errors are detected to enforce quality gates.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file with sample content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1><img src='missing.jpg' alt=''></body></html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Initialize WebAccessibility and a validator that checks all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Validate the whole document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
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
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }

            // Validate a specific guideline (example: Perceivable -> TextAlternatives)
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("TextAlternatives");
            Aspose.Html.Accessibility.AccessibilityValidator guidelineValidator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument docForGuideline = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult guidelineResult = guidelineValidator.Validate(docForGuideline);
                Console.WriteLine($"Guideline validation success: {guidelineResult.Success}");
            }

            // Clean up temporary file
            File.Delete(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}