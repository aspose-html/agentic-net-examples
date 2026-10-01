// Include linked images in MHTML output by enabling resource inclusion in MHTMLSaveOptions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string imagePath = "sample.png";
            string outputPath = "output.mhtml";

            // Create a minimal 1x1 PNG image
            byte[] pngBytes = new byte[]
            {
                0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A,
                0x00,0x00,0x00,0x0D,0x49,0x48,0x44,0x52,
                0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,
                0x08,0x06,0x00,0x00,0x00,0x1F,0x15,0xC4,
                0x89,0x00,0x00,0x00,0x0A,0x49,0x44,0x41,
                0x54,0x78,0x9C,0x63,0x60,0x00,0x00,0x00,
                0x02,0x00,0x01,0xE2,0x21,0xBC,0x33,0x00,
                0x00,0x00,0x00,0x49,0x45,0x4E,0x44,0xAE,
                0x42,0x60,0x82
            };
            File.WriteAllBytes(imagePath, pngBytes);

            // HTML content referencing the image
            string html = $"<html><body><h1>Sample</h1><img src=\"{imagePath}\" alt=\"Sample Image\"/></body></html>";

            // Configure MHTML save options to include linked resources
            MHTMLSaveOptions options = new MHTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;

            // Convert HTML to MHTML
            Aspose.Html.Converters.Converter.ConvertHTML(html, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}