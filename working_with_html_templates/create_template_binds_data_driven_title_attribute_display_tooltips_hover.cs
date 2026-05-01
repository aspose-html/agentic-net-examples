// Create a template that binds a data‑driven title attribute to display tooltips on hover.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Loading;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the template and the output HTML
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create a simple HTML template with a data‑driven title attribute
            string templateContent = @"
<html>
<head><title>Sample</title></head>
<body>
    <div title='{{title}}'>Hover over me</div>
</body>
</html>";
            File.WriteAllText(inputPath, templateContent);

            // JSON data that will replace the {{title}} placeholder
            string jsonData = @"{""title"":""This is a tooltip""}";

            // Load the template HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Prepare template data and loading options
            TemplateData data = new TemplateData(jsonData);
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Merge the template with the data and save the result
            Converter.ConvertTemplate(document, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}