// Save each downloaded external SVG file to the output folder with .svg extension.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving.ResourceHandlers;

class Program
{
    static void Main()
    {
        try
        {
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            string[] svgUrls = new string[]
            {
                "https://example.com/image1.svg",
                "https://example.com/image2.svg"
            };

            foreach (string url in svgUrls)
            {
                using (SVGDocument doc = new SVGDocument(url))
                {
                    doc.Save(new FileSystemResourceHandler(outputFolder));
                }
            }

            Console.WriteLine("SVG files saved to " + outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}