// Use AccessibilityRules.GetAll to fetch all WCAG rule codes and descriptions for UI display.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Example: retrieve a specific principle, guideline, and criterion
            // (Replace the string literals with actual IDs if needed)
            var principle = webAccessibility.Rules.GetPrinciple("Principle1");
            var guideline = principle?.GetGuideline("Guideline1.1");
            var criterion = guideline?.GetCriterion("1.1.1");

            if (criterion != null)
            {
                Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);

                // List sufficient techniques (rules) for the criterion
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                }
            }
            else
            {
                Console.WriteLine("Specified criterion not found. Unable to display WCAG rules.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}