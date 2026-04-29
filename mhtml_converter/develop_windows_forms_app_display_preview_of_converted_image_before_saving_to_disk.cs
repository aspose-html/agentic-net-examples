// Develop a Windows Forms app that displays a preview of the converted image before saving to disk.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string format = "JPEG";
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine("Converted image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath = Path.ChangeExtension(inputPath, format.Equals("JPEG", StringComparison.OrdinalIgnoreCase) ? ".jpg" : ".out");
        if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
        {
            var options = new ImageSaveOptions(ImageFormat.Jpeg);
            Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            var options = new XpsSaveOptions();
            Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            var options = new DocSaveOptions();
            Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else
        {
            throw new ArgumentException("Unsupported format: " + format);
        }
        return outputPath;
    }
}