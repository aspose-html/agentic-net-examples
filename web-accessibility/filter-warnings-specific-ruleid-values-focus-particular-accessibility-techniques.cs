// Filter warnings by specific RuleId values to focus on particular accessibility techniques.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='missing.jpg' alt=''></body></html>";
            // Create WebAccessibility instance
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            // Create validator with all rules
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Validate the document
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    // Define rule IDs to filter
                    string[] filterRuleIds = new string[] { "R1", "R2" }; // replace with actual rule IDs of interest
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success && ruleResult.Rule != null)
                        {
                            // Filter by specific RuleId (using Rule.Code as identifier)
                            if (System.Array.IndexOf(filterRuleIds, ruleResult.Rule.Code) >= 0)
                            {
                                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                    {
                                        System.Console.WriteLine(techResult.Error.ErrorMessage);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("No accessibility warnings detected.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}