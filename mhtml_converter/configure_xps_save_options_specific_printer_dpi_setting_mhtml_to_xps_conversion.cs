// Configure XpsSaveOptions to use a specific printer DPI setting during MHTML to XPS conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source MHTML file and the target XPS file
            string inputPath = "input.mhtml";
            string outputPath = "output.xps";

            // Open the MHTML file as a read-only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XpsSaveOptions and set printer DPI
                XpsSaveOptions options = new XpsSaveOptions();
                options.HorizontalResolution = 600; // DPI horizontally
                options.VerticalResolution = 600;   // DPI vertically

                // Perform the conversion
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML to XPS conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}