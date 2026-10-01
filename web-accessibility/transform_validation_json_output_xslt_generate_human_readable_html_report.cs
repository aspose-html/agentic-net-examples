// Transform validation JSON output using XSLT to generate a human‑readable HTML report.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample template and JSON data files
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create a simple HTML template with placeholders
            File.WriteAllText(templatePath,
                "<html><head><title>{{title}}</title></head><body><h1>{{title}}</h1></body></html>");

            // Create corresponding JSON data
            File.WriteAllText(jsonPath, "{\"title\":\"Hello Aspose\"}");

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(
                templatePath, templateData, loadOptions);

            // Save the resulting HTML document
            document.Save(outputPath);
            Console.WriteLine($"Converted HTML saved to: {outputPath}");

            // Perform accessibility validation
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator =
                webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            using (StringWriter sw = new StringWriter())
            {
                validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                Console.WriteLine("Accessibility validation result (XML):");
                Console.WriteLine(sw.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}