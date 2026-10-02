// Query a specific rule by code using AccessibilityRules.GetRule to show detailed guidance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility object
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Get a principle by its code (example code "1.1")
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("1.1");
            if (principle == null)
            {
                Console.WriteLine("Principle with the specified code was not found.");
                return;
            }

            // Get a guideline from the principle (example code "1.1.1")
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1.1");
            if (guideline == null)
            {
                Console.WriteLine("Guideline with the specified code was not found.");
                return;
            }

            // Get a criterion from the guideline (example code "1.1.1.1")
            Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1.1");
            if (criterion == null)
            {
                Console.WriteLine("Criterion with the specified code was not found.");
                return;
            }

            // Output criterion details
            Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);

            // List sufficient techniques (rules) for the criterion
            foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
            {
                Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}