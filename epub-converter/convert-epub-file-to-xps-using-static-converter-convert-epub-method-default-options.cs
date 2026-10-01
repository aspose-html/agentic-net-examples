// Convert an EPUB file to XPS using the static Converter.ConvertEPUB method with default options.

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
            string sourcePath = "sample.epub";
            string outputPath = "output.xps";

            if (!File.Exists(sourcePath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(sourcePath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}