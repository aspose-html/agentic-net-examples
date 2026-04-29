// Write validation results to a JSON file by calling ValidationResult.SaveTo with Json format.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string jsonPath = "validationResult.json";

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                using (StringWriter writer = new StringWriter())
                {
                    validationResult.SaveTo(writer, ValidationResultSaveFormat.JSON);
                    File.WriteAllText(jsonPath, writer.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}