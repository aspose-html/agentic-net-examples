// Create a command‑line tool that accepts input MHTML path and output format argument for conversion.

using System;
using System.IO;

namespace MhtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "input.mhtml";
                string format = args.Length > 1 ? args[1] : "XPS";

                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "Dummy MHTML content");
                }

                string outputPath = ConvertMhtmlByFormat(inputPath, format);
                Console.WriteLine($"Conversion completed. Output file: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string ConvertMhtmlByFormat(string inputPath, string format)
        {
            string directory = Path.GetDirectoryName(inputPath);
            string baseName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath;

            using (FileStream stream = File.OpenRead(inputPath))
            {
                switch (format.ToUpperInvariant())
                {
                    case "XPS":
                        outputPath = Path.Combine(directory, baseName + ".xps");
                        var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, xpsOptions, outputPath);
                        break;
                    case "DOCX":
                        outputPath = Path.Combine(directory, baseName + ".docx");
                        var docOptions = new Aspose.Html.Saving.DocSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, docOptions, outputPath);
                        break;
                    case "JPEG":
                        outputPath = Path.Combine(directory, baseName + ".jpg");
                        var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, imgOptions, outputPath);
                        break;
                    default:
                        throw new ArgumentException("Unsupported format: " + format);
                }
            }

            return outputPath;
        }
    }
}