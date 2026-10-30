// Create a command‑line tool that accepts input MHTML path and output format argument for conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.mhtml";
            string format = args.Length > 1 ? args[1] : "XPS";

            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine("Conversion succeeded. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (!File.Exists(inputPath))
            throw new FileNotFoundException("Input MHTML file not found.", inputPath);

        string outputPath;
        using (FileStream stream = File.OpenRead(inputPath))
        {
            if (string.Equals(format, "XPS", StringComparison.OrdinalIgnoreCase))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".xps");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (string.Equals(format, "DOCX", StringComparison.OrdinalIgnoreCase))
            {
                DocSaveOptions options = new DocSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".docx");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (string.Equals(format, "JPEG", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(format, "JPG", StringComparison.OrdinalIgnoreCase))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                outputPath = Path.ChangeExtension(inputPath, ".jpg");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else
            {
                throw new ArgumentException("Unsupported format: " + format);
            }
        }

        return outputPath;
    }
}