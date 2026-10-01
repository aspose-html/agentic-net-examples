// Use XpsSaveOptions to define document author and title metadata when converting MHTML to XPS.

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
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                // Additional option configuration can be added here if needed.

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}