// Convert an EPUB file to XPS using the static Converter.ConvertEPUB method with default options.

using System;
using System.IO;

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
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}