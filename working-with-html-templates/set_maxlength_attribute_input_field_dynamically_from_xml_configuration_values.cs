// Set the maxlength attribute of an input field dynamically from XML configuration values.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file if it does not exist
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><p id=\"p1\">Hello World</p></body></html>");
            }

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Modify an element
            var element = document.QuerySelector("#p1");
            if (element != null)
            {
                element.SetAttribute("style", "color:red;");
            }

            // Save modified HTML
            string outputHtmlPath = "output.html";
            document.Save(outputHtmlPath);

            // Render to XPS
            var xpsOptions = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            var anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)));
            xpsOptions.PageSetup.AnyPage = anyPage;
            string xpsPath = "output.xps";
            var xpsDevice = new Aspose.Html.Rendering.Xps.XpsDevice(xpsOptions, xpsPath);
            document.RenderTo(xpsDevice);

            // Convert to DOC using DocSaveOptions
            var docOptions = new Aspose.Html.Saving.DocSaveOptions();
            var docPageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));
            var docPage = new Aspose.Html.Drawing.Page(docPageSize);
            docOptions.PageSetup.AnyPage = docPage;
            string docPath = "output.doc";
            Aspose.Html.Converters.Converter.ConvertHTML(document, docOptions, docPath);

            // Create a new HTML document from scratch
            var newDoc = new Aspose.Html.HTMLDocument();
            var body = newDoc.Body;
            var paragraph = (Aspose.Html.HTMLParagraphElement)newDoc.CreateElement("p");
            paragraph.SetAttribute("style", "font-weight:bold;");
            var textNode = newDoc.CreateTextNode("Generated paragraph.");
            paragraph.AppendChild(textNode);
            body.AppendChild(paragraph);
            string generatedHtmlPath = "generated.html";
            newDoc.Save(generatedHtmlPath);

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}