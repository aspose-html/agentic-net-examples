// Apply TemplateLoadOptions to enable loading HTML templates that contain external CSS references for styling.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample files
            string inputPath = "template.html";
            string cssPath = "style.css";
            string outputPath = "output.html";

            // Create external CSS file
            File.WriteAllText(cssPath, "body { background-color: #e5f3fd; }");

            // Create HTML template that references the external CSS
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""style.css"">
</head>
<body>
    <p>Hello, {{name}}!</p>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML template
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (JSON format)
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"name\":\"World\"}");

            // Apply TemplateLoadOptions to enable external CSS loading
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with data and options
            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            result.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}