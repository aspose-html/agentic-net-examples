// Write a method that returns warning counts grouped by each target element type for analysis.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string inputDir = "InputHtml";
            Directory.CreateDirectory(inputDir);
            string file1 = Path.Combine(inputDir, "sample.html");
            string file2 = Path.Combine(inputDir, "sample2.html");
            File.WriteAllText(file1, "<html><body><img src='image.png'></body></html>");
            File.WriteAllText(file2, "<html><body><button>Click</button></body></html>");

            // 1. Basic accessibility validation and element details
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(file1))
            {
                var validationResult = validator.Validate(document);
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
                                    var element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }

            // 2. Retrieve principle, guideline, criterion and list sufficient techniques
            var principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            var guideline = principle.GetGuideline("Text Alternatives");
            var criterion = guideline.GetCriterion("Non-text Content");
            if (criterion != null)
            {
                Console.WriteLine($"{criterion.Code}:{criterion.Description} - {criterion.Level}");
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine($"{technique.Code}:{technique.Description}");
                }
            }

            // 3. Validate multiple URLs and save results to XML files
            List<string> urls = new List<string> { file1, file2 };
            string outputDir = "ValidationResults";
            Directory.CreateDirectory(outputDir);
            int index = 1;
            foreach (string url in urls)
            {
                using (var doc = new Aspose.Html.HTMLDocument(url))
                {
                    var result = validator.Validate(doc);
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, result.ToString());
                }
                index++;
            }

            Console.WriteLine("Validation results saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}