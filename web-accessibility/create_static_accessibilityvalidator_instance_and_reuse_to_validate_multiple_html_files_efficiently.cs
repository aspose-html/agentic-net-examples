// Create a static AccessibilityValidator instance and reuse it to validate multiple HTML files efficiently.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file for validation
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg'></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Initialize accessibility validator
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the document and perform validation
            using (var document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                var error = techResult.Error;
                                Console.WriteLine(error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}