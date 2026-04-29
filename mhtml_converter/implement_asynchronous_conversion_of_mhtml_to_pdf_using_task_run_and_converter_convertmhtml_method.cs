// Implement asynchronous conversion of MHTML to PDF using Task.Run and Converter.ConvertMHTML method.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            await Task.Run(() =>
            {
                FileStream stream = File.OpenRead(inputPath);
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
                stream.Dispose();
            });

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}