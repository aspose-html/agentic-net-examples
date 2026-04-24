// Convert EPUB to PNG and define ImageSaveOptions.Margins to create uniform padding for images.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string pngPath = "output.png";

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();

                // Define uniform padding of 20 points on all sides
                int padding = 20;
                // Define page size (optional, can be adjusted as needed)
                int pageWidth = 800;
                int pageHeight = 600;

                options.PageSetup.AnyPage = new Page(
                    new Size(pageWidth, pageHeight),
                    new Margin(padding, padding, padding, padding));

                Converter.ConvertEPUB(epubStream, options, pngPath);
            }

            Console.WriteLine("EPUB successfully converted to PNG with padding.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}