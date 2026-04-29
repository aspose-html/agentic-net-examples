// Read ValidationResult.Description to obtain a high‑level summary of the accessibility check outcome.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument("<html><body><video></video></body></html>"))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                Console.WriteLine($"Success: {validationResult.Success}");
                Console.WriteLine("Summary:");
                Console.WriteLine(validationResult.SaveToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}