// Use TemplateData to bind a list of products from JSON and generate a repeating product card layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // HTML template with a placeholder
            string htmlTemplate = "<html><body><h1>{{title}}</h1></body></html>";

            // JSON data to fill the template
            string jsonData = "{\"title\":\"Hello Aspose.HTML!\"}";

            // Create template data object
            var templateData = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options (default)
            var loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to an HTMLDocument
            var document = Aspose.Html.Converters.Converter.ConvertTemplate(
                htmlTemplate,
                string.Empty,
                templateData,
                loadOptions);

            // Save the resulting HTML
            string htmlOutputPath = "output.html";
            document.Save(htmlOutputPath);
            Console.WriteLine($"HTML saved to: {Path.GetFullPath(htmlOutputPath)}");

            // Render the document to a PNG image
            var imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            string imageOutputPath = "output.png";
            var imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, imageOutputPath);
            document.RenderTo(imgDevice);
            Console.WriteLine($"Image saved to: {Path.GetFullPath(imageOutputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}