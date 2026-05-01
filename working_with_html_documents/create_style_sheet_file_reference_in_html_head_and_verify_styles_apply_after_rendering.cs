// Create a style sheet file, reference it in the HTML head, and verify styles apply after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string cssPath = "styles.css";
            string htmlPath = "sample.html";
            string outputPath = "rendered.png";

            // Create external CSS file
            File.WriteAllText(cssPath, "body { background-color: rgb(229, 243, 253); } h1 { color: red; }");

            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();

            // Build basic HTML structure
            HTMLElement html = (HTMLElement)document.CreateElement("html");
            HTMLElement head = (HTMLElement)document.CreateElement("head");
            HTMLElement body = (HTMLElement)document.CreateElement("body");

            document.AppendChild(html);
            html.AppendChild(head);
            html.AppendChild(body);

            // Reference the external stylesheet
            HTMLElement link = (HTMLElement)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", cssPath);
            head.AppendChild(link);

            // Add sample content
            HTMLElement h1 = (HTMLElement)document.CreateElement("h1");
            h1.TextContent = "Hello Aspose.HTML";
            body.AppendChild(h1);

            // Save the HTML document
            document.Save(htmlPath);

            // Render the HTML to an image to verify the stylesheet is applied
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}