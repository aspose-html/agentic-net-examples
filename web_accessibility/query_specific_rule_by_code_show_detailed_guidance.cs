// Query a specific rule by code using AccessibilityRules.GetRule to show detailed guidance.

using System;
using Aspose.Html.Accessibility;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize the WebAccessibility object
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get a principle by its WCAG code (e.g., "1")
            Principle principle = webAccessibility.Rules.GetPrinciple("1");
            if (principle == null)
            {
                Console.WriteLine("Principle not found.");
                return;
            }

            // Get a guideline under the principle (e.g., "1.1")
            Guideline guideline = principle.GetGuideline("1.1");
            if (guideline == null)
            {
                Console.WriteLine("Guideline not found.");
                return;
            }

            // Get a specific criterion (e.g., "1.1.1")
            Criterion criterion = guideline.GetCriterion("1.1.1");
            if (criterion != null)
            {
                // Output criterion details
                Console.WriteLine($"{criterion.Code}: {criterion.Description} - {criterion.Level}");

                // List all sufficient techniques for the criterion
                foreach (IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine($"{technique.Code}: {technique.Description}");
                }
            }
            else
            {
                Console.WriteLine("Criterion not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}