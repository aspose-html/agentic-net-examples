// Develop a command‑line tool accepting input path and output format arguments to perform validation on demand.

using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "sample.html";
        string format = args.Length > 1 ? args[1].ToLowerInvariant() : "string";
        if (!File.Exists(inputPath))
        {
            File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello</p></body></html>");
        }
        try
        {
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (format == "xml")
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                        Console.WriteLine(sw.ToString());
                    }
                }
                else
                {
                    string resultString = validationResult.SaveToString();
                    Console.WriteLine(resultString);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}