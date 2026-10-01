// Load a template with custom base URL using TemplateLoadOptions to resolve relative links.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output paths
            string inputPath = "template.html";
            string outputHtmlPath = "output.html";
            string outputPdfPath = "output.pdf";
            string outputImagePath = "output.png";

            // Create a minimal template file if it does not exist
            if (!File.Exists(inputPath))
            {
                string templateContent = @"
<html>
<head><title>Template Example</title></head>
<body>
<h1>{{title}}</h1>
<p>This is a sample template.</p>
</body>
</html>";
                File.WriteAllText(inputPath, templateContent);
            }

            // Load the HTML template document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (simple XML with a root element)
            string xmlData = @"<data><title>Welcome to Aspose.HTML</title></data>";
            var data = new Aspose.Html.Converters.TemplateData(xmlData);

            // Load options for template processing
            var loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the provided data
            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, loadOptions);

            // Save the resulting HTML document
            resultDocument.Save(outputHtmlPath);
            Console.WriteLine($"HTML output saved to: {Path.GetFullPath(outputHtmlPath)}");

            // Render the result to PDF
            var pdfOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            var pdfDevice = new Aspose.Html.Rendering.Doc.DocDevice(pdfOptions, outputPdfPath);
            resultDocument.RenderTo(pdfDevice);
            Console.WriteLine($"PDF output saved to: {Path.GetFullPath(outputPdfPath)}");

            // Render the result to PNG image
            var imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            var imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputImagePath);
            resultDocument.RenderTo(imgDevice);
            Console.WriteLine($"Image output saved to: {Path.GetFullPath(outputImagePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}