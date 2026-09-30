// Render an HTML document to XPS with landscape orientation by setting XpsRenderingOptions.PageOrientation.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, XPS!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure XPS rendering options for landscape orientation
            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.White;
            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11.0),
                    Aspose.Html.Drawing.Length.FromInches(8.5)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
            options.PageSetup.AnyPage = anyPage;

            // Set output XPS file path
            string savePath = "output.xps";

            // Render to XPS
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, savePath);
            document.RenderTo(device);

            Console.WriteLine("HTML has been successfully rendered to XPS in landscape orientation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}