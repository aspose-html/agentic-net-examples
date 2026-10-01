// Use AccessibilityRules.GetAll to fetch all WCAG rule codes and descriptions for UI display.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file to work with
            string inputPath = "sample.html";
            File.WriteAllText(inputPath,
                "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Accessibility Test</h1></body></html>");

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Initialize the accessibility engine
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve a principle (example code "1.1")
            var principle = webAccessibility.Rules.GetPrinciple("1.1");
            if (principle != null)
            {
                // Retrieve a guideline (example code "1.1.1")
                var guideline = principle.GetGuideline("1.1.1");
                if (guideline != null)
                {
                    // Retrieve a criterion (example code "1.1.1.1")
                    var criterion = guideline.GetCriterion("1.1.1.1");
                    if (criterion != null)
                    {
                        Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);

                        // List sufficient techniques for the criterion
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
                else
                {
                    Console.WriteLine("Guideline not found.");
                }
            }
            else
            {
                Console.WriteLine("Principle not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}