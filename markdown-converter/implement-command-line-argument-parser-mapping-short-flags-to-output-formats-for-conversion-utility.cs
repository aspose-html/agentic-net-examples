// Implement a command‑line argument parser that maps short flags to output formats for the conversion utility.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input and output settings
            string inputPath = "sample.html";
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Determine target format based on command‑line flags
            // Supported short flags:
            // -p : PDF
            // -i : PNG image
            // -j : JPEG image
            // -g : GIF image
            // -m : Markdown
            // -h : HTML (copy)
            string format = "pdf"; // default format
            foreach (string arg in args)
            {
                if (arg.StartsWith("-") && arg.Length == 2)
                {
                    char flag = arg[1];
                    switch (flag)
                    {
                        case 'p':
                            format = "pdf";
                            break;
                        case 'i':
                            format = "png";
                            break;
                        case 'j':
                            format = "jpeg";
                            break;
                        case 'g':
                            format = "gif";
                            break;
                        case 'm':
                            format = "markdown";
                            break;
                        case 'h':
                            format = "html";
                            break;
                    }
                }
            }

            // Build output path based on selected format
            string outputPath = Path.Combine(outputDirectory, "output");
            switch (format)
            {
                case "pdf":
                    outputPath += ".pdf";
                    var pdfOptions = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(inputPath, pdfOptions, outputPath);
                    break;
                case "png":
                    outputPath += ".png";
                    var pngOptions = new ImageSaveOptions(ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertHTML(inputPath, pngOptions, outputPath);
                    break;
                case "jpeg":
                    outputPath += ".jpeg";
                    var jpegOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                    Aspose.Html.Converters.Converter.ConvertHTML(inputPath, jpegOptions, outputPath);
                    break;
                case "gif":
                    outputPath += ".gif";
                    var gifOptions = new ImageSaveOptions(ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertHTML(inputPath, gifOptions, outputPath);
                    break;
                case "markdown":
                    outputPath += ".md";
                    var mdOptions = new MarkdownSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(inputPath, mdOptions, outputPath);
                    break;
                case "html":
                    outputPath += ".html";
                    // For HTML, simply copy the source file
                    File.Copy(inputPath, outputPath, true);
                    break;
                default:
                    throw new InvalidOperationException("Unsupported format: " + format);
            }

            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}