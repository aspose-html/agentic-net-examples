// Save validation results to an XML file for compatibility with legacy systems and workflows.

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

            string outputPath = "validation_results.xml";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string xmlContent = sw.ToString();
                    System.IO.File.WriteAllText(outputPath, xmlContent);
                }
            }

            System.Console.WriteLine("Validation results saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}