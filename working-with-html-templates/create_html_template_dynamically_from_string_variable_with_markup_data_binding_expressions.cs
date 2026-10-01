// Create an HTML template dynamically from a string variable containing markup with data‑binding expressions.

using System;
using System.IO;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Ensure a minimal input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>{{title}}</title></head><body><h1>{{title}}</h1></body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (JSON format)
            var data = new Aspose.Html.Converters.TemplateData("{\"title\":\"Hello, Aspose!\"}");

            // Set template load options (default)
            var options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template
            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting document
            resultDocument.Save(outputPath);

            Console.WriteLine($"Template conversion completed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during template conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}