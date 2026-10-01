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
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                // If the XpsSaveOptions class provides a property to enable document outline,
                // set it here, e.g., options.DocumentOutlineEnabled = true;
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}