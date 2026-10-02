// Generate a PNG preview by converting the template to HTML and rendering the result to an image.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample template HTML with placeholder
            string htmlCode = "<html><body><h1>Hello, {{name}}</h1></body></html>";
            // Sample XML data source
            string dataSource = "<root><name>World</name></root>";

            // Prepare template options and data
            Aspose.Html.Converters.TemplateContentOptions templateOptions = new Aspose.Html.Converters.TemplateContentOptions(dataSource, Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateOptions);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template to HTML document
            Aspose.Html.HTMLDocument htmlDocument = Aspose.Html.Converters.Converter.ConvertTemplate(htmlCode, string.Empty, templateData, loadOptions);

            // Define output PNG path
            string outputPath = "output.png";

            // Configure image rendering options
            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();

            // Create image device and render
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
            htmlDocument.RenderTo(imgDevice);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}