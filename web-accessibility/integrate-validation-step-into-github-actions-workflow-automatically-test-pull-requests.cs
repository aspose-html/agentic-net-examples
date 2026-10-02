// Integrate the validation step into a GitHub Actions workflow to automatically test pull requests.

namespace Example
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                // Initialize WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

                // Load HTML document using two-argument constructor (content, baseUri)
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        System.Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                    }
                    System.Environment.ExitCode = 1;
                }
                else
                {
                    System.Console.WriteLine("Validation succeeded.");
                    System.Environment.ExitCode = 0;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine($"Error: {ex.Message}");
                System.Environment.ExitCode = 1;
            }

            return System.Environment.ExitCode;
        }
    }
}