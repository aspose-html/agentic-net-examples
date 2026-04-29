// Create a command‑line tool that accepts input Markdown path and output format arguments for conversion.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Usage: <markdownPath> <outputFormat>");

            string sourcePath = args[0];
            string format = args[1].ToLowerInvariant();
            string outputPath = System.IO.Path.ChangeExtension(sourcePath, format == "html" ? ".html" :
                                                                 format == "docx" ? ".docx" :
                                                                 format == "gif" ? ".gif" :
                                                                 format == "bmp" ? ".bmp" :
                                                                 ".out");

            switch (format)
            {
                case "html":
                    Converter.ConvertMarkdown(sourcePath, outputPath);
                    break;

                case "docx":
                    HTMLDocument documentDocx = Converter.ConvertMarkdown(sourcePath);
                    Converter.ConvertHTML(documentDocx, new DocSaveOptions(), outputPath);
                    break;

                case "gif":
                    HTMLDocument documentGif = Converter.ConvertMarkdown(sourcePath);
                    ImageSaveOptions gifOptions = new ImageSaveOptions(ImageFormat.Gif);
                    Converter.ConvertHTML(documentGif, gifOptions, outputPath);
                    break;

                case "bmp":
                    HTMLDocument documentBmp = Converter.ConvertMarkdown(sourcePath);
                    ImageSaveOptions bmpOptions = new ImageSaveOptions(ImageFormat.Bmp);
                    Converter.ConvertHTML(documentBmp, bmpOptions, outputPath);
                    break;

                default:
                    throw new NotSupportedException($"Format '{format}' is not supported.");
            }

            Console.WriteLine($"Conversion succeeded. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}