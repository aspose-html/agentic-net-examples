// Combine validation findings with SEO metrics to identify pages with both accessibility and ranking issues.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

namespace AsposeHtmlAccessibilitySeoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample URLs to validate
                List<string> urls = new List<string>
                {
                    "https://example.com/page1.html",
                    "https://example.com/page2.html"
                };

                // Simulated SEO scores for each URL
                Dictionary<string, double> seoScores = new Dictionary<string, double>
                {
                    { "https://example.com/page1.html", 45.0 },
                    { "https://example.com/page2.html", 80.0 }
                };

                double rankingThreshold = 50.0; // Scores below this are considered low

                // Initialize accessibility validator
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                int index = 1;
                foreach (string url in urls)
                {
                    using (HTMLDocument document = new HTMLDocument(url))
                    {
                        ValidationResult validationResult = validator.Validate(document);
                        bool hasAccessibilityIssues = !validationResult.Success;

                        // Output accessibility error details if any
                        if (hasAccessibilityIssues)
                        {
                            foreach (RuleValidationResult ruleResult in validationResult.Details)
                            {
                                if (!ruleResult.Success)
                                {
                                    foreach (ITechniqueResult techResult in ruleResult.Errors)
                                    {
                                        if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                        {
                                            HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                            string tagName = element.TagName;
                                            string id = element.GetAttribute("id");
                                            Console.WriteLine($"Accessibility Issue - Tag: {tagName}, Id: {id}, Message: {techResult.Error.ErrorMessage}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Accessibility Issue - Message: {techResult.Error.ErrorMessage}");
                                        }
                                    }
                                }
                            }
                        }

                        // Determine SEO issue
                        double seoScore = 0;
                        bool hasSeoIssue = seoScores.TryGetValue(url, out seoScore) && seoScore < rankingThreshold;

                        // Combine results
                        if (hasAccessibilityIssues && hasSeoIssue)
                        {
                            Console.WriteLine($"Page {index}: {url} has accessibility issues and low SEO score ({seoScore}).");
                        }
                        else if (hasAccessibilityIssues)
                        {
                            Console.WriteLine($"Page {index}: {url} has accessibility issues (SEO score {seoScore}).");
                        }
                        else if (hasSeoIssue)
                        {
                            Console.WriteLine($"Page {index}: {url} has low SEO score ({seoScore}) but no accessibility issues.");
                        }
                        else
                        {
                            Console.WriteLine($"Page {index}: {url} passes both checks (SEO score {seoScore}).");
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
}