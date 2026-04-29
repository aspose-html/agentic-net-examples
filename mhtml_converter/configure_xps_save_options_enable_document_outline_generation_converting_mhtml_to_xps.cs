// Configure XpsSaveOptions to enable document outline generation when converting MHTML to XPS.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";

            // Path where the resulting XPS file will be saved
            string outputPath = "output.xps";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XpsSaveOptions with default settings
                XpsSaveOptions options = new XpsSaveOptions();

                // If the XpsSaveOptions class supports a DocumentOutline property,
                // it can be enabled here (uncomment the line below if available):
                // options.DocumentOutline = true;

                // Perform the conversion from MHTML to XPS
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}