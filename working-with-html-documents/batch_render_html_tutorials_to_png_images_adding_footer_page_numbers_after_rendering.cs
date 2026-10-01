// Batch render HTML tutorials to PNG images, adding a footer with page numbers after rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML files and output PNG files
            string[] htmlFiles = new string[] { "tutorial1.html", "tutorial2.html", "tutorial3.html" };
            string[] pngFiles = new string[] { "tutorial1.png", "tutorial2.png", "tutorial3.png" };

            // Create minimal sample HTML files if they do not exist
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                if (!File.Exists(htmlFiles[i]))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Tutorial " + (i + 1) + "</title></head><body><h1>Tutorial " + (i + 1) + "</h1><p>This is sample content for tutorial " + (i + 1) + ".</p></body></html>";
                    File.WriteAllText(htmlFiles[i], sampleHtml);
                }
            }

            // Process each tutorial
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                // Load HTML document from file
                string documentPath = htmlFiles[i];
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

                // Add footer with page number
                Aspose.Html.HTMLElement footer = (Aspose.Html.HTMLElement)document.CreateElement("div");
                footer.InnerHTML = "Page " + (i + 1);
                footer.SetAttribute("style", "position:fixed; bottom:0; width:100%; text-align:center; font-size:12px; background-color:rgba(255,255,255,0.5);");
                document.Body.AppendChild(footer);

                // Prepare rendering options and device
                Aspose.Html.Rendering.Image.ImageRenderingOptions opt = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(opt, pngFiles[i]);

                // Render to PNG
                document.RenderTo(device);
            }

            Console.WriteLine("Batch rendering completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}