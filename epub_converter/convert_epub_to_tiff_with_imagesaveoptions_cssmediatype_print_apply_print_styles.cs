// Convert EPUB to TIFF with ImageSaveOptions.CssMediaType configured as 'print' to apply print styles.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Open the EPUB file as a readable stream
            using (Stream epubStream = File.OpenRead("input.epub"))
            {
                // Create image save options for TIFF format
                ImageSaveOptions saveOptions = new ImageSaveOptions(ImageFormat.Tiff);
                
                // Apply print media CSS rules during rendering
                saveOptions.Css.MediaType = MediaType.Print;
                
                // Convert the EPUB to a TIFF image file
                Converter.ConvertEPUB(epubStream, saveOptions, "output.tiff");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}