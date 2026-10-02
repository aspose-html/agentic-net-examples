// Save downloaded icons to a dedicated icons directory using a custom naming convention.

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
            // Create output directory for icons
            string iconsDirectory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "icons");
            System.IO.Directory.CreateDirectory(iconsDirectory);

            // Prepare a simple SVG that references an external icon
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>" +
                                "<image href='https://example.com/favicon.ico' width='32' height='32'/>" +
                                "</svg>";

            // Save SVG content to a temporary file
            string svgFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.svg");
            System.IO.File.WriteAllText(svgFilePath, svgContent);

            // Load SVG document and save external resources (icons) to the icons directory
            using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(svgFilePath))
            {
                doc.Save(new Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler(iconsDirectory));
            }

            // Apply custom naming convention to downloaded icons
            string[] files = System.IO.Directory.GetFiles(iconsDirectory);
            int index = 1;
            foreach (string filePath in files)
            {
                string extension = System.IO.Path.GetExtension(filePath);
                string newFileName = System.IO.Path.Combine(iconsDirectory, $"custom_icon_{index}{extension}");
                System.IO.File.Move(filePath, newFileName);
                index++;
            }

            System.Console.WriteLine("Icons have been saved to: " + iconsDirectory);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}