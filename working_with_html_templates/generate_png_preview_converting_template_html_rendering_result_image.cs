// Generate a PNG preview by converting the template to HTML and rendering the result to an image.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // HTML template with a placeholder attribute
            string htmlTemplate = "<html><body><input type='checkbox' attr='${attr}'/></body></html>";

            // XML data that provides the value for the placeholder
            string xmlData = "<root><attr>checked</attr></root>";

            // Convert the template to an HTMLDocument
            HTMLDocument htmlDocument = Converter.ConvertTemplate(
                htmlTemplate,
                string.Empty,
                new TemplateData(new TemplateContentOptions(xmlData, TemplateContent.XML)),
                new TemplateLoadOptions());

            // Access the first input element
            HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();

            // Output the checked state (for demonstration)
            Console.WriteLine("Checked: " + input.Checked);

            // Save the populated HTML to a file
            string htmlOutputPath = "output.html";
            htmlDocument.Save(htmlOutputPath);

            // Render the HTMLDocument to a PNG image
            ImageRenderingOptions imgOptions = new ImageRenderingOptions();
            ImageDevice imgDevice = new ImageDevice(imgOptions, "output.png");
            htmlDocument.RenderTo(imgDevice);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}