// Run default accessibility validation and direct console output to a debug logger for development monitoring.

using System;
using System.Diagnostics;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    Debug.WriteLine("Accessibility validation succeeded.");
                }
                else
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (IError error in ruleResult.Errors)
                            {
                                Debug.WriteLine(error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}