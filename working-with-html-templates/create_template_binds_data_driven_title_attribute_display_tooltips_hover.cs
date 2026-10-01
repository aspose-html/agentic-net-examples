// Create a template that binds a data‑driven title attribute to display tooltips on hover.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string outputPath = "output.html";

            // Create a simple HTML template with a data‑driven title attribute
            string templateContent = @"<html><body><div title=""{{title}}"">Hover over me</div></body></html>";
            File.WriteAllText(templatePath, templateContent);

            // JSON data that provides the title value
            string jsonData = @"{""title"":""This is a tooltip displayed on hover""}";

            // Load the template document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(templatePath);

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Apply the data to the template
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML with the bound title attribute
            resultDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}