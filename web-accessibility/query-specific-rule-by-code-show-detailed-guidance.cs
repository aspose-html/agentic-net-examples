// Query a specific rule by code using AccessibilityRules.GetRule to show detailed guidance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve the specific principle, guideline, and criterion
            var principle = webAccessibility.Rules.GetPrinciple("WCAG2AA.Principle1");
            if (principle == null)
            {
                Console.WriteLine("Principle not found.");
                return;
            }

            var guideline = principle.GetGuideline("Guideline1_1");
            if (guideline == null)
            {
                Console.WriteLine("Guideline not found.");
                return;
            }

            var criterion = guideline.GetCriterion("Criterion1_1.1");
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
            Console.WriteLine("An error occurred: {0}", ex.Message);
        }
    }
}