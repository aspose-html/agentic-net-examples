// Write a method that returns a list of error messages for a specified rule identifier.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string htmlFilePath = "sample.html";

            // Initialize accessibility services
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(htmlFilePath))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Example: retrieve error messages for a specific rule code
                string targetRuleCode = "WCAG2.1.1"; // replace with desired rule identifier
                List<string> errors = GetErrorMessages(targetRuleCode, validationResult);

                Console.WriteLine($"Errors for rule {targetRuleCode}:");
                foreach (string msg in errors)
                {
                    Console.WriteLine("- " + msg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static List<string> GetErrorMessages(string ruleCode, ValidationResult validationResult)
    {
        List<string> messages = new List<string>();

        if (validationResult == null)
            return messages;

        foreach (RuleValidationResult detail in validationResult.Details)
        {
            if (detail.Rule != null && string.Equals(detail.Rule.Code, ruleCode, StringComparison.OrdinalIgnoreCase))
            {
                foreach (IError error in detail.Errors)
                {
                    if (error != null && !string.IsNullOrEmpty(error.ErrorMessage))
                        messages.Add(error.ErrorMessage);
                }
                break;
            }
        }

        return messages;
    }
}