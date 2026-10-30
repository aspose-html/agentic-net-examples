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
            List<string> errors = GetErrorMessages("IMG_1");
            Console.WriteLine("Error messages for rule 'IMG_1':");
            foreach (string msg in errors)
            {
                Console.WriteLine("- " + msg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static List<string> GetErrorMessages(string ruleId)
    {
        // Sample HTML with an image missing alt attribute (common accessibility issue)
        string htmlContent = "<html><body><img src='image.png'></body></html>";
        // Create a WebAccessibility instance
        WebAccessibility webAccessibility = new WebAccessibility();
        // Create a validator with all rules
        AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
        // Load the HTML content (using two-argument constructor to avoid file path interpretation)
        HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
        // Perform validation
        ValidationResult validationResult = validator.Validate(document);
        // Collect error messages for the specified rule identifier
        List<string> messages = new List<string>();
        foreach (RuleValidationResult ruleResult in validationResult.Details)
        {
            if (ruleResult.Rule != null && ruleResult.Rule.Code == ruleId)
            {
                foreach (IError error in ruleResult.Errors)
                {
                    messages.Add(error.ErrorMessage);
                }
            }
        }
        return messages;
    }
}