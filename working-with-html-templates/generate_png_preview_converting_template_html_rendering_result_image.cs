// Generate a PNG preview by converting the template to HTML and rendering the result to an image.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with a placeholder attribute
            string htmlTemplate = @"<html><body><input type='checkbox' attr='{{attr}}' /></body></html>";

            // XML data defining the placeholder value
            string xmlData = @"<root><attr>checked</attr></root>";

            // Convert the template to a populated HTML document
            Aspose.Html.HTMLDocument htmlDocument = Aspose.Html.Converters.Converter.ConvertTemplate(
                htmlTemplate,
                string.Empty,
                new Aspose.Html.Converters.TemplateData(
                    new Aspose.Html.Converters.TemplateContentOptions(xmlData, Aspose.Html.Converters.TemplateContent.XML)
                ),
                new Aspose.Html.Loading.TemplateLoadOptions()
            );

            // Retrieve the first input element and display its Checked state
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();
            Console.WriteLine("Checked: " + input.Checked);

            // Save the resulting HTML to a file
            string htmlOutputPath = "output.html";
            htmlDocument.Save(htmlOutputPath);

            // Render the HTML document to a PNG image
            string pngOutputPath = "output.png";
            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, pngOutputPath);
            htmlDocument.RenderTo(imgDevice);

            Console.WriteLine("HTML and PNG files have been generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}