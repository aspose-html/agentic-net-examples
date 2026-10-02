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
            // Define input MHTML file path and ensure it exists
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Hello, Aspose.HTML!</p></body></html>");
            }

            // Define output XPS file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Open the source MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create XpsSaveOptions instance
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}