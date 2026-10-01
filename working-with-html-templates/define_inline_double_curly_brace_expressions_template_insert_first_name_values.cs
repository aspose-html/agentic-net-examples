// Define inline double‑curly‑brace expressions in the template to insert first name values.

using System;
using System.IO;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create minimal sample files if they do not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><body><h1>{{title}}</h1><p>{{message}}</p></body></html>");
            }

            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath,
                    "{ \"title\": \"Hello World\", \"message\": \"This is a sample message.\" }");
            }

            // Load the HTML template
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Load the JSON data for the template
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Set template load options (default options are sufficient here)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Perform the template conversion
            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML document
            result.Save(outputPath);

            Console.WriteLine($"Template conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}