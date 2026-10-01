// Convert all <i> tags to <em> tags for better accessibility compliance throughout the document.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string sampleHtml = "<html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            string inputFilePath = "sample.html";
            File.WriteAllText(inputFilePath, sampleHtml);

            // Initialize WebAccessibility and validator (all rules)
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validatorAll = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // 1. Detailed validation with element info
            using (var document = new Aspose.Html.HTMLDocument(inputFilePath))
            {
                var validationResult = validatorAll.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // 2. Simple error messages
            using (var document = new Aspose.Html.HTMLDocument(inputFilePath))
            {
                var validationResult = validatorAll.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }

            // 3. Success / failure message
            using (var document = new Aspose.Html.HTMLDocument(inputFilePath))
            {
                var validationResult = validatorAll.Validate(document);
                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }

            // 4. Validation using a specific principle and guideline (if available)
            try
            {
                Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Principle1");
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("Guideline1");
                var validatorGuideline = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
                using (var document = new Aspose.Html.HTMLDocument(inputFilePath))
                {
                    var validationResult = validatorGuideline.Validate(document);
                    Console.WriteLine("Guideline validation completed. Success: " + validationResult.Success);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Guideline validation skipped: " + ex.Message);
            }

            // 5. Batch validation of URLs and save results as XML files
            List<string> urls = new List<string> { "https://example.com", "https://example.org" };
            string outputDir = "validation_results";
            Directory.CreateDirectory(outputDir);
            int index = 1;
            foreach (string url in urls)
            {
                using (var document = new Aspose.Html.HTMLDocument(url))
                {
                    var validationResult = validatorAll.Validate(document);
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());
                }
                index++;
            }

            Console.WriteLine("All operations completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}