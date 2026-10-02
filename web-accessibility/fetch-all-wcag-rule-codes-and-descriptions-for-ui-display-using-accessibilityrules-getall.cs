// Use AccessibilityRules.GetAll to fetch all WCAG rule codes and descriptions for UI display.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility object
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve a specific principle (replace with a valid principle code if needed)
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("1.1");
            if (principle != null)
            {
                // Retrieve a specific guideline (replace with a valid guideline code if needed)
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1.1");
                if (guideline != null)
                {
                    // Retrieve a specific criterion (replace with a valid criterion code if needed)
                    Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1.1");
                    if (criterion != null)
                    {
                        // Output criterion information
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