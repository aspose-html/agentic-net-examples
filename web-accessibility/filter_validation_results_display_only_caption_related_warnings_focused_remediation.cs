// Filter validation results to display only caption‑related warnings for focused remediation efforts.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with an accessibility issue (image without alt)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempHtmlPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempHtmlPath))
            {
                // Create WebAccessibility and validator for all rules
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Validate the document
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Output validation result as string (JSON)
                string resultJson = validationResult.SaveToString();
                Console.WriteLine("Validation Result (JSON):");
                Console.WriteLine(resultJson);
                Console.WriteLine();

                // If validation failed, print detailed information
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Print rule code and description
                            Console.WriteLine($"{ruleResult.Rule.Code} - {ruleResult.Rule.Description}");

                            // Iterate over technique errors
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine($"  Message: {error.ErrorMessage}");

                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine($"  Element: {element.OuterHTML}");
                                }
                            }

                            Console.WriteLine();
                        }
                    }
                }

                // Demonstrate accessing a specific principle and guideline (if they exist)
                Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Principle1");
                if (principle != null)
                {
                    Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("Guideline1");
                    if (guideline != null)
                    {
                        Aspose.Html.Accessibility.AccessibilityValidator guidelineValidator =
                            webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
                        Aspose.Html.Accessibility.Results.ValidationResult guidelineResult = guidelineValidator.Validate(document);

                        Console.WriteLine("Guideline-specific validation completed.");
                        Console.WriteLine($"Success: {guidelineResult.Success}");
                    }
                }

                // Additional detailed output similar to the original snippet
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        if (!detail.Success)
                        {
                            Console.WriteLine($"{detail.Rule.Code} : {detail.Rule.Description}");
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine(error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine(element.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(tempHtmlPath))
            {
                File.Delete(tempHtmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}