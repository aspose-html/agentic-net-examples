// Access ValidationResult.Errors collection to count total accessibility errors found in the document.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file for validation
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.jpg'></body></html>";
            string inputFilePath = "sample.html";
            File.WriteAllText(inputFilePath, htmlContent, Encoding.UTF8);

            // Initialize WebAccessibility and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputFilePath))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        if (!detail.Success)
                        {
                            Console.WriteLine(detail.Rule.Code + " - " + detail.Rule.Description);
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine("Error: " + error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine("Element: " + element.OuterHTML);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation successfully.");
                }
            }

            // Clean up the temporary file
            if (File.Exists(inputFilePath))
            {
                File.Delete(inputFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}