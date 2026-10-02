// Batch render HTML tutorials to PNG images, adding a footer with page numbers after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define sample HTML file paths
            string[] htmlFiles = new string[]
            {
                "tutorial1.html",
                "tutorial2.html",
                "tutorial3.html"
            };

            // Create sample HTML files if they do not exist
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                if (!File.Exists(htmlFiles[i]))
                {
                    string sampleHtml = $"<html><body><h1>Tutorial {i + 1}</h1><p>This is sample content for tutorial {i + 1}.</p></body></html>";
                    File.WriteAllText(htmlFiles[i], sampleHtml);
                }
            }

            // Process each HTML file
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string inputPath = htmlFiles[i];
                string outputPath = $"output_{i + 1}.png";

                // Load HTML document from file
                Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(inputPath);

                // Create footer element with page number
                Aspose.Html.HTMLElement footer = (Aspose.Html.HTMLElement)htmlDocument.CreateElement("div");
                footer.SetAttribute("style", "position:fixed; bottom:0; left:0; width:100%; text-align:center; font-size:12px; background-color:rgba(255,255,255,0.5);");
                footer.InnerHTML = $"Page {i + 1}";

                // Append footer to body
                htmlDocument.Body.AppendChild(footer);

                // Set rendering options (page size)
                Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                imgOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

                // Create image device and render to PNG file
                Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
                htmlDocument.RenderTo(imgDevice);

                // Cleanup
                imgDevice.Dispose();
                htmlDocument.Dispose();

                Console.WriteLine($"Rendered '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}