// Create a command‑line tool that accepts input MHTML path and output format argument for conversion.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: MhtmlConverter <input.mhtml> <format>");
                    return;
                }

                string inputPath = args[0];
                string format = args[1].ToLowerInvariant();

                string outputPath = ConvertMhtmlByFormat(inputPath, format);
                Console.WriteLine($"Converted to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string ConvertMhtmlByFormat(string inputPath, string format)
        {
            using (FileStream stream = File.OpenRead(inputPath))
            {
                string outputPath;
                switch (format)
                {
                    case "xps":
                        outputPath = Path.ChangeExtension(inputPath, ".xps");
                        XpsSaveOptions xpsOptions = new XpsSaveOptions();
                        Converter.ConvertMHTML(stream, xpsOptions, outputPath);
                        break;
                    case "docx":
                        outputPath = Path.ChangeExtension(inputPath, ".docx");
                        DocSaveOptions docOptions = new DocSaveOptions();
                        Converter.ConvertMHTML(stream, docOptions, outputPath);
                        break;
                    case "jpeg":
                    case "jpg":
                        outputPath = Path.ChangeExtension(inputPath, ".jpg");
                        ImageSaveOptions imgOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                        Converter.ConvertMHTML(stream, imgOptions, outputPath);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported format: {format}");
                }
                return outputPath;
            }
        }
    }
}