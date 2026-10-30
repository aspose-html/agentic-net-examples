// Load an HTML file from a local path into the validator for WCAG analysis.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.html";
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
                }

                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                System.Console.WriteLine("Validation Success: " + validationResult.Success);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        System.Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}