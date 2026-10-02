// Convert HTML to TIFF using a network share UNC path as source and handle potential latency.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = @"\\server\share\input.html";
            string outputPath = @"\\server\share\output.tiff";

            const int maxAttempts = 2;
            int attempt = 0;
            bool success = false;

            while (attempt < maxAttempts && !success)
            {
                try
                {
                    var document = new Aspose.Html.HTMLDocument(inputPath);
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    success = true;
                    Console.WriteLine("Conversion succeeded: " + outputPath);
                }
                catch (Exception ex)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                    {
                        throw;
                    }
                    Console.WriteLine("Conversion failed (attempt " + attempt + "): " + ex.Message);
                    Console.WriteLine("Retrying after a short delay...");
                    Thread.Sleep(2000);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}