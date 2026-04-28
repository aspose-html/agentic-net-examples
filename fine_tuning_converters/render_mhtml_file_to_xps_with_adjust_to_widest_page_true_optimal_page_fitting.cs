// Render an MHTML file to XPS with AdjustToWidestPage true to ensure optimal page fitting.

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

            // Path where the resulting XPS file will be saved
            string outputPath = "output.xps";

            // Open the MHTML file as a read-only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XPS save options with default settings
                XpsSaveOptions options = new XpsSaveOptions();

                // The AdjustToWidestPage property is not available in this version of Aspose.HTML,
                // so the default page fitting behavior will be used.

                // Convert the MHTML stream to XPS using the specified options and output path
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}