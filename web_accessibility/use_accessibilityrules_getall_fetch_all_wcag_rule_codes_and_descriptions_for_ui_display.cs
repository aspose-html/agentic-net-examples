// Use AccessibilityRules.GetAll to fetch all WCAG rule codes and descriptions for UI display.

using System;
using Aspose.Html.Accessibility;

class Program
{
    static void Main()
    {
        try
        {
            var webAccessibility = new WebAccessibility();
            var principles = webAccessibility.Rules.GetPrinciples();
            foreach (var principle in principles)
            {
                Console.WriteLine($"{principle.Code}: {principle.Description}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}