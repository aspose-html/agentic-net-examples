// Iterate AccessibilityRules.AdvisoryTechniques to list improvement suggestions for each identified issue.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize the WebAccessibility object
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create a validator that includes all accessibility rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document to be validated
            using (var document = new Aspose.Html.HTMLDocument("input.html"))
            {
                // Perform validation
                var validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    // Iterate over each rule result that failed
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Cast the rule to Criterion to access advisory techniques
                            var criterion = ruleResult.Rule as Aspose.Html.Accessibility.Criterion;
                            if (criterion != null)
                            {
                                Console.WriteLine($"Rule: {criterion.Code} - {criterion.Description}");

                                // List improvement suggestions from AdvisoryTechniques
                                foreach (var technique in criterion.AdvisoryTechniques)
                                {
                                    Console.WriteLine($"  Suggestion: {technique.Code} - {technique.Description}");
                                }
                            }

                            // Output error messages for the rule
                            foreach (var techResult in ruleResult.Errors)
                            {
                                Console.WriteLine($"Error: {techResult.Error.ErrorMessage}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}