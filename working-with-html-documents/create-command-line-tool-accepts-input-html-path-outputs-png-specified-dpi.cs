// Create a command‑line tool that accepts an input HTML path and outputs a PNG with specified DPI.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.html";
            string outputPath = args.Length > 1 ? args[1] : "output.png";
            int dpi = args.Length > 2 ? int.Parse(args[2]) : 300;

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = dpi;
            options.VerticalResolution = dpi;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine($"Converted '{inputPath}' to PNG at '{outputPath}' with DPI {dpi}.");
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}