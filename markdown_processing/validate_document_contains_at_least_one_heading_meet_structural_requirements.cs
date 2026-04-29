// Validate that the document contains at least one heading to meet structural requirements.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace HeadingValidationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the HTML file to be validated
                string htmlPath = "sample.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Initialize the accessibility engine
                WebAccessibility webAccessibility = new WebAccessibility();

                // Create a validator that includes all accessibility rules
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Output overall validation status
                Console.WriteLine($"Accessibility validation success: {validationResult.Success}");

                // If validation failed, output details
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult detail in validationResult.Details)
                    {
                        if (!detail.Success)
                        {
                            Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description}");
                            foreach (ITechniqueResult techResult in detail.Errors)
                            {
                                Console.WriteLine($"  Error: {techResult.Error.ErrorMessage}");
                            }
                        }
                    }
                }

                // Check for at least one heading (h1‑h6) in the document
                int headingCount = 0;
                for (int level = 1; level <= 6; level++)
                {
                    var headings = document.GetElementsByTagName($"h{level}");
                    headingCount += headings.Length;
                }

                if (headingCount > 0)
                {
                    Console.WriteLine($"Document contains {headingCount} heading element(s).");
                }
                else
                {
                    Console.WriteLine("Document does not contain any heading elements (h1‑h6).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}