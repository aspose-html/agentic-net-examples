// Convert an MHTML file to XPS format while specifying custom page dimensions in XpsSaveOptions.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired output XPS file path
            string outputPath = "output.xps";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Set custom page size: 8.3 inches width × 5.8 inches height
                options.PageSetup.AnyPage = new Page(
                    new Size(Length.FromInches(8.3f), Length.FromInches(5.8f))
                );

                // Set the background color to AliceBlue
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Perform the conversion from MHTML stream to XPS file
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}