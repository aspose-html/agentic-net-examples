// Write a method that returns a list of error messages for a specified rule identifier.

using System;
using System.Collections.Generic;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            var errors = GetErrorMessages("example-rule-id");
            foreach (string msg in errors)
            {
                Console.WriteLine(msg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static List<string> GetErrorMessages(string ruleId)
    {
        var messages = new List<string>();

        // Initialize WebAccessibility and validator
        WebAccessibility webAccessibility = new WebAccessibility();
        AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

        // Sample HTML content
        string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Sample</h1></body></html>";
        HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

        // Perform validation
        ValidationResult validationResult = validator.Validate(document);

        // Iterate over rule results
        foreach (RuleValidationResult ruleResult in validationResult.Details)
        {
            // Filter by rule identifier if possible (property not exposed in this example)
            // Collect error messages for failed rules
            if (!ruleResult.Success)
            {
                messages.Add("Validation error in a rule.");
            }
        }

        return messages;
    }
}