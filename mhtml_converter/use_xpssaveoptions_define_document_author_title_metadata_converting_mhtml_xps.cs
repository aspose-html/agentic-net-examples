// Use XpsSaveOptions to define document author and title metadata when converting MHTML to XPS.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired path for the resulting XPS file
            string outputPath = "output.xps";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XpsSaveOptions with default settings
                XpsSaveOptions options = new XpsSaveOptions();

                // The XpsSaveOptions class in the current Aspose.HTML version
                // does not expose DocumentTitle or DocumentAuthor properties.
                // If such properties become available, they can be set here,
                // e.g., options.DocumentTitle = "My Title";

                // Perform the conversion from MHTML to XPS
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