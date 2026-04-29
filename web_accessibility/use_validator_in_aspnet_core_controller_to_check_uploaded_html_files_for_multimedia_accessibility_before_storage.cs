// Use the validator in an ASP.NET Core controller to check uploaded HTML files for multimedia accessibility before storage.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AsposeHtmlValidatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Expect a single argument: path to the HTML file to validate
                if (args.Length != 1)
                {
                    Console.WriteLine("Usage: AsposeHtmlValidatorExample <html-file-path>");
                    return;
                }

                string htmlPath = args[0];
                if (!File.Exists(htmlPath))
                {
                    Console.WriteLine($"File not found: {htmlPath}");
                    return;
                }

                // 1. Create WebAccessibility instance
                WebAccessibility webAccessibility = new WebAccessibility();

                // 2. Retrieve the guideline for the "1.2" principle (Time‑Based Media)
                var guideline = webAccessibility.Rules
                                                .GetPrinciple("1.2")
                                                .GetGuideline("Time-Based Media");

                // 3. Create an AccessibilityValidator with all validation settings
                AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, ValidationBuilder.All);

                // 4. Load the HTML document from the supplied file path
                HTMLDocument document = new HTMLDocument(htmlPath);

                // 5. Execute validation
                ValidationResult validationResult = validator.Validate(document);

                // 6. Check overall success and output details if there are failures
                if (validationResult.Success)
                {
                    Console.WriteLine("Validation succeeded: no multimedia accessibility issues found.");
                }
                else
                {
                    Console.WriteLine("Validation failed: multimedia accessibility issues detected.");
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Output rule identifier (if available) and any error messages
                            string ruleInfo = ruleResult.Rule?.GetType().Name ?? "UnknownRule";
                            Console.WriteLine($"- Rule: {ruleInfo}");

                            foreach (var error in ruleResult.Errors)
                            {
                                // Many error objects expose a Message property; fallback to ToString()
                                string message = error?.GetType().GetProperty("Message")?.GetValue(error) as string;
                                Console.WriteLine($"  Error: {message ?? error?.ToString()}");
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
}