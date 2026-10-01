// Convert a template that uses conditional attribute binding for readonly fields based on data flags.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with a checkbox input
            string htmlTemplate = "<!DOCTYPE html><html><body><input type='checkbox' id='chk'></body></html>";
            bool isChecked = true;
            string outputHtmlPath = "output.html";
            string outputImagePath = "output.png";

            // Load the template HTML document from the string
            var templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "");

            // Prepare template data (empty XML content for demonstration)
            var contentOptions = new Aspose.Html.Converters.TemplateContentOptions("<root></root>", Aspose.Html.Converters.TemplateContent.XML);
            var templateData = new Aspose.Html.Converters.TemplateData(contentOptions);
            var loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with the provided data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            // Set the checkbox state
            var input = (Aspose.Html.HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;

            // Save the resulting HTML document
            resultDocument.Save(outputHtmlPath);
            Console.WriteLine($"HTML saved to: {Path.GetFullPath(outputHtmlPath)}");

            // Render the HTML document to an image
            var imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            var imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputImagePath);
            resultDocument.RenderTo(imgDevice);
            Console.WriteLine($"Image rendered to: {Path.GetFullPath(outputImagePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}