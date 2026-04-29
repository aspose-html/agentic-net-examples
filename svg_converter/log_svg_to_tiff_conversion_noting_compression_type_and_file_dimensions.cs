// Log each SVG to TIFF conversion, noting compression type and resulting file dimensions.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(outputFolder);

            foreach (string svgPath in Directory.GetFiles(inputFolder, "*.svg"))
            {
                // Load SVG document
                SVGDocument document = new SVGDocument(svgPath);

                // Set up TIFF conversion options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.Compression = Compression.None;
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                // Define output TIFF path
                string tiffPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                // Perform conversion
                Converter.ConvertSVG(document, options, tiffPath);

                // Load resulting TIFF to obtain dimensions
                using (Image tiffImage = Image.FromFile(tiffPath))
                {
                    Console.WriteLine($"Converted '{Path.GetFileName(svgPath)}' to '{Path.GetFileName(tiffPath)}'. " +
                                      $"Compression: {options.Compression}, " +
                                      $"Dimensions: {tiffImage.Width}x{tiffImage.Height}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}