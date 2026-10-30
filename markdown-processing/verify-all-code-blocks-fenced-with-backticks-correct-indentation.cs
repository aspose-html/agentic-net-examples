// Verify that all code blocks are fenced with backticks and correct any that use indentation.

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow scripts (if any)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

                // Output validation summary
                System.Console.WriteLine("Overall Success: {0}", result.Success);

                // Iterate over each rule result
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in result.Details)
                {
                    if (ruleResult.Rule != null)
                    {
                        System.Console.WriteLine("Rule {0}: {1} - Success: {2}",
                            ruleResult.Rule.Code,
                            ruleResult.Rule.Description,
                            ruleResult.Success);
                    }
                    else
                    {
                        System.Console.WriteLine("Unnamed Rule - Success: {0}", ruleResult.Success);
                    }

                    // If the rule failed, list associated errors
                    if (!ruleResult.Success && ruleResult.Errors != null)
                    {
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                        {
                            if (techResult.Error != null)
                            {
                                System.Console.WriteLine("  Error: {0}", techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: {0}", ex.Message);
        }
    }
}