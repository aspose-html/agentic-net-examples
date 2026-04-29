// Develop a command‑line tool accepting input path and output format arguments to perform validation on demand.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <inputHtmlPath> [format]");
                return;
            }

            string inputPath = args[0];
            string format = args.Length > 1 ? args[1].ToLower() : "xml";

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    if (format == "xml")
                    {
                        validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    }
                    else
                    {
                        sw.Write(validationResult.SaveToString());
                    }

                    Console.WriteLine(sw.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}