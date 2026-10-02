// Configure the validator to treat caption missing warnings as errors by adjusting severity settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a table missing a caption
            string htmlContent = "<html><body><table><tr><td>Data</td></tr></table></body></html>";

            // Create a WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create a validator that includes all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML content (use two‑argument constructor to avoid file‑path interpretation)
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Validation succeeded: no accessibility issues found.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        // Treat missing caption warnings as errors
                        bool isCaptionMissingWarning = string.Equals(ruleResult.Rule.Code, "CaptionMissing", StringComparison.OrdinalIgnoreCase);

                        if (!ruleResult.Success || isCaptionMissingWarning)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine($"Error: {techResult.Error.ErrorMessage}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}