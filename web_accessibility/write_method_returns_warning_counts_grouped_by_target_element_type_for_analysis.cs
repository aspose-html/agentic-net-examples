// Write a method that returns warning counts grouped by each target element type for analysis.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AsposeHtmlWarningCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Example HTML file path; replace with actual path as needed
                string htmlPath = "sample.html";

                var warningCounts = GetWarningCounts(htmlPath);

                foreach (var kvp in warningCounts)
                {
                    Console.WriteLine($"Target Type: {kvp.Key}, Warning Count: {kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Returns a dictionary with warning counts grouped by each target element type
        static Dictionary<TargetTypes, int> GetWarningCounts(string htmlFilePath)
        {
            var result = new Dictionary<TargetTypes, int>();

            // Initialize the WebAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create a validator that includes all rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlFilePath))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Iterate over each rule result
                foreach (RuleValidationResult ruleResult in validationResult.Details)
                {
                    // Process warnings for the current rule
                    foreach (ITechniqueResult techResult in ruleResult.Warnings)
                    {
                        // Determine the target type of the warning
                        TargetTypes targetType = techResult.Error.Target.TargetType;

                        // Increment count for this target type
                        if (result.ContainsKey(targetType))
                            result[targetType]++;
                        else
                            result[targetType] = 1;
                    }
                }
            }

            return result;
        }
    }
}