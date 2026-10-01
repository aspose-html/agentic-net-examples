// Call ValidationResult.SaveToString to obtain a formatted string of errors and warnings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        if (!detail.Success)
                        {
                            Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine("Error: " + error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine("Element HTML: " + element.OuterHTML);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }

            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}