// Implement a method that returns a dictionary mapping each supported output format to its conversion success flag.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file (using plain HTML content for demo purposes)
            string mhtmlPath = "sample.mhtml";
            File.WriteAllText(mhtmlPath, "<html><body><h1>Hello World</h1></body></html>");

            var results = ConvertMhtmlToAllFormats(mhtmlPath);

            foreach (var kvp in results)
            {
                Console.WriteLine($"{kvp.Key}: {(kvp.Value ? "Success" : "Failed")}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, bool> ConvertMhtmlToAllFormats(string mhtmlPath)
    {
        var formatSuccess = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        var requestedFormats = new List<string>
        {
            "PDF",
            "DOCX",
            "XPS",
            "JPEG",
            "PNG",
            "BMP",
            "GIF",
            "TIFF"
        };

        foreach (var format in requestedFormats)
        {
            bool success = false;
            try
            {
                using (FileStream inputStream = File.OpenRead(mhtmlPath))
                {
                    string outputPath = GetOutputPath(mhtmlPath, format);
                    if (IsDocumentFormat(format))
                    {
                        // Document formats
                        if (format.Equals("PDF", StringComparison.OrdinalIgnoreCase))
                        {
                            var options = new PdfSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                        }
                        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
                        {
                            var options = new DocSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                        }
                        else if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
                        {
                            var options = new XpsSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                        }
                    }
                    else
                    {
                        // Image formats
                        ImageFormat imgFormat = GetImageFormat(format);
                        var options = new ImageSaveOptions(imgFormat);
                        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                    }

                    success = File.Exists(outputPath);
                }
            }
            catch
            {
                success = false;
            }

            formatSuccess[format] = success;
        }

        return formatSuccess;
    }

    static bool IsDocumentFormat(string format)
    {
        return format.Equals("PDF", StringComparison.OrdinalIgnoreCase) ||
               format.Equals("DOCX", StringComparison.OrdinalIgnoreCase) ||
               format.Equals("XPS", StringComparison.OrdinalIgnoreCase);
    }

    static ImageFormat GetImageFormat(string format)
    {
        if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
            return ImageFormat.Jpeg;
        if (format.Equals("PNG", StringComparison.OrdinalIgnoreCase))
            return ImageFormat.Png;
        if (format.Equals("BMP", StringComparison.OrdinalIgnoreCase))
            return ImageFormat.Bmp;
        if (format.Equals("GIF", StringComparison.OrdinalIgnoreCase))
            return ImageFormat.Gif;
        if (format.Equals("TIFF", StringComparison.OrdinalIgnoreCase))
            return ImageFormat.Tiff;

        // Default fallback
        return ImageFormat.Png;
    }

    static string GetOutputPath(string inputPath, string format)
    {
        string directory = Path.GetDirectoryName(inputPath);
        string baseName = Path.GetFileNameWithoutExtension(inputPath);
        string extension;

        if (format.Equals("PDF", StringComparison.OrdinalIgnoreCase))
            extension = ".pdf";
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
            extension = ".docx";
        else if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
            extension = ".xps";
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
            extension = ".jpg";
        else if (format.Equals("PNG", StringComparison.OrdinalIgnoreCase))
            extension = ".png";
        else if (format.Equals("BMP", StringComparison.OrdinalIgnoreCase))
            extension = ".bmp";
        else if (format.Equals("GIF", StringComparison.OrdinalIgnoreCase))
            extension = ".gif";
        else if (format.Equals("TIFF", StringComparison.OrdinalIgnoreCase))
            extension = ".tiff";
        else
            extension = ".out";

        return Path.Combine(directory ?? "", baseName + extension);
    }
}