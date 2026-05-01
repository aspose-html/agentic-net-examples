// Populate a template with nested JSON objects and display nested property values using dot notation.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the template HTML, JSON data, and output file
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Load JSON data for merging
            TemplateData templateData = new TemplateData(jsonPath);

            // Use default template load options
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Populate the template with the JSON data and save the result
            Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);

            // Display the populated HTML content
            string result = File.ReadAllText(outputPath);
            Console.WriteLine("Populated HTML:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}