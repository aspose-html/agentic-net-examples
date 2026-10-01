// Read ValidationResult.Description to obtain a high‑level summary of the accessibility check outcome.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file with sample content
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><div id='test' aria-label=''></div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Initialize accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // First validation block: detailed output
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
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
                                    string attributeValue = element.GetAttribute("id");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
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

            // Second validation block: simple error messages
            using (Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult2 = validator.Validate(document2);
                if (!validationResult2.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult2.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(htmlPath))
                File.Delete(htmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}