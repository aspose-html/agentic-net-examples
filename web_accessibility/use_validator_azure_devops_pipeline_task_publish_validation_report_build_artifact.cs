// Use the validator in an Azure DevOps pipeline task to publish a validation report as a build artifact.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <htmlPath> <reportPath>");
                return;
            }

            string htmlPath = args[0];
            string reportPath = args[1];

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    string xmlReport = sw.ToString();
                    File.WriteAllText(reportPath, xmlReport);
                    Console.WriteLine("Validation report saved to " + reportPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}