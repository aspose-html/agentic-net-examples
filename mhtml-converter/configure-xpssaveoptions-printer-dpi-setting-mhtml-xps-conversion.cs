// Configure XpsSaveOptions to use a specific printer DPI setting during MHTML to XPS conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            // Open the source MHTML file as a read stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure XpsSaveOptions with DPI and page settings
                XpsSaveOptions options = new XpsSaveOptions();
                options.HorizontalResolution = 300; // Desired printer DPI (horizontal)
                options.VerticalResolution = 300;   // Desired printer DPI (vertical)
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Define page size (8.3 x 5.8 inches) and assign to PageSetup
                Page page = new Page(
                    new Size(
                        Length.FromInches(8.3f),
                        Length.FromInches(5.8f)),
                    new Margin(0, 0, 0, 0));
                options.PageSetup.AnyPage = page;

                // Perform the conversion from MHTML to XPS
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}