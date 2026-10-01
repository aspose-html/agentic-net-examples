// Use the validator in an Azure DevOps pipeline task to publish a validation report as a build artifact.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello</h1></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string xmlReport = sw.ToString();
                    string outputPath = "validation_report.xml";
                    System.IO.File.WriteAllText(outputPath, xmlReport);
                    Console.WriteLine("Validation report saved to " + outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}