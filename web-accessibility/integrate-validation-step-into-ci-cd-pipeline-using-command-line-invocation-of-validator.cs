// Integrate the validation step into a CI/CD pipeline using a command‑line invocation of the validator.

using System;
using System.IO;

namespace AsposeHtmlValidationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "sample.html";
                string outputPath = args.Length > 1 ? args[1] : null;

                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                    Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    using (StringWriter sw = new StringWriter())
                    {
                        validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                        string xmlReport = sw.ToString();

                        if (validationResult.Success)
                        {
                            Console.WriteLine("Validation succeeded.");
                        }
                        else
                        {
                            Console.WriteLine("Validation failed. Details:");
                        }

                        if (!string.IsNullOrEmpty(outputPath))
                        {
                            File.WriteAllText(outputPath, xmlReport);
                            Console.WriteLine($"Validation report saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine(xmlReport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}