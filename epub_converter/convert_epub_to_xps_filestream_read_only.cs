// Convert an EPUB file to XPS by reading the source via FileStream with read‑only access.

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
            // Path to the source EPUB file
            string inputPath = "input.epub";

            // Desired output XPS file path
            string outputPath = "output.xps";

            // Open the EPUB file as a read‑only stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Initialize default XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert the EPUB stream to XPS and write directly to the output file
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during conversion
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}