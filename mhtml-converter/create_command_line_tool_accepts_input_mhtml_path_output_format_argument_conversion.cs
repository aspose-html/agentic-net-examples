// Create a command‑line tool that accepts input MHTML path and output format argument for conversion.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.mhtml";
            string format = args.Length > 1 ? args[1] : "XPS";

            if (!File.Exists(inputPath))
            {
                // Create a minimal MHTML file (simple HTML content)
                string htmlContent = "<html><body><h1>Sample MHTML</h1><p>This is a test.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine($"Conversion successful. Output file: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath;
        using (FileStream stream = File.OpenRead(inputPath))
        {
            if (string.Equals(format, "XPS", StringComparison.OrdinalIgnoreCase))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".xps");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (string.Equals(format, "DOCX", StringComparison.OrdinalIgnoreCase))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".docx");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (string.Equals(format, "JPEG", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(format, "JPG", StringComparison.OrdinalIgnoreCase))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                outputPath = Path.ChangeExtension(inputPath, ".jpg");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else
            {
                throw new ArgumentException($"Unsupported format: {format}");
            }
        }
        return outputPath;
    }
}