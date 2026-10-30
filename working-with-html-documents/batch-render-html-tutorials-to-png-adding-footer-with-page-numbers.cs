// Batch render HTML tutorials to PNG images, adding a footer with page numbers after rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define sample HTML tutorial files
            string[] tutorialFiles = new string[] { "tutorial1.html", "tutorial2.html", "tutorial3.html" };

            // Ensure sample files exist
            for (int i = 0; i < tutorialFiles.Length; i++)
            {
                string path = tutorialFiles[i];
                if (!File.Exists(path))
                {
                    string sampleHtml = $"<html><head><title>Tutorial {i + 1}</title></head><body><h1>Tutorial {i + 1}</h1><p>Content of tutorial {i + 1}.</p></body></html>";
                    File.WriteAllText(path, sampleHtml);
                }
            }

            // Process each tutorial
            for (int i = 0; i < tutorialFiles.Length; i++)
            {
                string inputPath = tutorialFiles[i];
                string outputPath = Path.GetFileNameWithoutExtension(inputPath) + ".png";

                // Load HTML document
                Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(inputPath);

                // Create footer with page number
                Aspose.Html.Dom.Element footerElement = htmlDocument.CreateElement("div");
                ((Aspose.Html.HTMLElement)footerElement).InnerHTML = $"Page {i + 1}";
                footerElement.SetAttribute("style", "position:fixed;bottom:0;width:100%;text-align:center;background-color:#f0f0f0;font-size:14px;padding:5px;");

                // Append footer to body
                htmlDocument.Body.AppendChild(footerElement);

                // Set rendering options (e.g., 800x600 pixels)
                Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                imgOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

                // Render to PNG file
                Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
                htmlDocument.RenderTo(imgDevice);
                imgDevice.Dispose();

                Console.WriteLine($"Rendered '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}