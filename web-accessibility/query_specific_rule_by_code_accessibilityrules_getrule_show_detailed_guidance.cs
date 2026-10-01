// Query a specific rule by code using AccessibilityRules.GetRule to show detailed guidance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Initialize WebAccessibility
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve principle, guideline, and criterion
            var principle = webAccessibility.Rules.GetPrinciple("1.1");
            var guideline = principle?.GetGuideline("1.1.1");
            var criterion = guideline?.GetCriterion("1.1.1.1");

            if (criterion != null)
            {
                Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                }
            }
            else
            {
                Console.WriteLine("Criterion not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}