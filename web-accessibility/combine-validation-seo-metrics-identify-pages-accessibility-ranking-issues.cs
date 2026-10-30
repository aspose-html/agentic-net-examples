// Combine validation findings with SEO metrics to identify pages with both accessibility and ranking issues.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "sample_pages");
            Directory.CreateDirectory(baseDir);

            string page1Path = Path.Combine(baseDir, "page1.html");
            string page2Path = Path.Combine(baseDir, "page2.html");

            // page1 has an image without alt attribute (accessibility issue)
            File.WriteAllText(page1Path, "<!DOCTYPE html><html><head><title>Page 1</title></head><body><img src=\"image.png\"></body></html>");
            // page2 is fine
            File.WriteAllText(page2Path, "<!DOCTYPE html><html><head><title>Page 2</title></head><body><img src=\"image.png\" alt=\"Sample image\"></body></html>");

            // List of pages to analyze
            List<string> pages = new List<string> { page1Path, page2Path };

            // Mock SEO scores (lower means worse ranking)
            Dictionary<string, int> seoScores = new Dictionary<string, int>
            {
                { page1Path, 55 }, // low ranking
                { page2Path, 85 }  // good ranking
            };
            int rankingThreshold = 70;

            // Initialize accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            int index = 1;
            foreach (string pagePath in pages)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pagePath))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    bool hasAccessibilityIssues = !validationResult.Success;

                    bool hasRankingIssue = seoScores.ContainsKey(pagePath) && seoScores[pagePath] < rankingThreshold;

                    if (hasAccessibilityIssues && hasRankingIssue)
                    {
                        Console.WriteLine($"Page {index} ({pagePath}) has both accessibility and ranking issues.");
                        // Output accessibility details
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
                                        Console.WriteLine($"  Tag: {tagName}, Alt attribute: {(attributeValue ?? "null")}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"  Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                        Console.WriteLine($"  SEO score: {seoScores[pagePath]} (threshold: {rankingThreshold})");
                    }
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}