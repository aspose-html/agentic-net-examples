// Develop a GUI application that lets users select MHTML files and choose output format from a dropdown.

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
            string inputPath = "sample.mhtml";
            string format = "DOCX";
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine("Converted file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (!File.Exists(inputPath))
            throw new FileNotFoundException("Input file not found.", inputPath);

        string outputPath;
        using (Stream stream = File.OpenRead(inputPath))
        {
            switch (format.ToUpperInvariant())
            {
                case "XPS":
                    outputPath = Path.ChangeExtension(inputPath, ".xps");
                    XpsSaveOptions xpsOptions = new XpsSaveOptions();
                    Converter.ConvertMHTML(stream, xpsOptions, outputPath);
                    break;
                case "DOCX":
                    outputPath = Path.ChangeExtension(inputPath, ".docx");
                    DocSaveOptions docOptions = new DocSaveOptions();
                    Converter.ConvertMHTML(stream, docOptions, outputPath);
                    break;
                case "JPEG":
                case "JPG":
                    outputPath = Path.ChangeExtension(inputPath, ".jpg");
                    ImageSaveOptions imgOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                    Converter.ConvertMHTML(stream, imgOptions, outputPath);
                    break;
                default:
                    throw new ArgumentException("Unsupported format: " + format);
            }
        }
        return outputPath;
    }
}