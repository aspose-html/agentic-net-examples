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
            // Create a minimal MHTML (HTML) file for demonstration
            File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");

            using (Stream stream = File.OpenRead(inputPath))
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                // Set custom document title based on the source filename (without extension)
                pdfOptions.DocumentInfo.Title = Path.GetFileNameWithoutExtension(inputPath);

                string outputPath = "output.pdf";

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}