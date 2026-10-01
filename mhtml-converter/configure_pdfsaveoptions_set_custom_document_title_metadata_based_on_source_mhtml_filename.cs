// Configure PdfSaveOptions to set a custom document title metadata based on the source MHTML filename.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.DocumentInfo.Title = Path.GetFileNameWithoutExtension(inputPath);
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