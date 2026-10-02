// Use the validator in an Azure DevOps pipeline task to publish a validation report as a build artifact.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create accessibility validator with all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation details if any rule failed
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                }
            }

            // Save validation report as XML file (artifact)
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                string reportXml = sw.ToString();
                string reportPath = "validation_report.xml";
                System.IO.File.WriteAllText(reportPath, reportXml);
                Console.WriteLine($"Validation report saved to {reportPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}