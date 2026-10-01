// Convert HTML to TIFF by parsing command line arguments for input and output paths in a console app.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.html";
            string outputPath = args.Length > 1 ? args[1] : "output.tiff";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Input: " + inputPath);
            Console.WriteLine("Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}