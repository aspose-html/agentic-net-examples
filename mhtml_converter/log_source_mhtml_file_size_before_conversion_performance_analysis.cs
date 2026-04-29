// Implement logging of source MHTML file size before conversion to assist in performance analysis.

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

            // Directory and path for the output XPS file
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "output.xps");

            // Log the size of the source MHTML file
            FileInfo fileInfo = new FileInfo(inputPath);
            Console.WriteLine($"Source MHTML file size: {fileInfo.Length} bytes");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the MHTML file as a readable stream (lifecycle rule)
            FileStream stream = File.OpenRead(inputPath);

            // Create XPS save options (lifecycle rule)
            XpsSaveOptions options = new XpsSaveOptions();

            // Perform the conversion from MHTML to XPS (lifecycle rule)
            Converter.ConvertMHTML(stream, options, outputPath);

            // Close the input stream
            stream.Close();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}