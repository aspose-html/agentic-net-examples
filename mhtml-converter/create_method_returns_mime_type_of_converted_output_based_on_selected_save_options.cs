// Create a method that returns the MIME type of the converted output based on selected save options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file as input
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Convert to JPEG format
            string format = "JPEG";
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine($"Output file: {outputPath}");

            // Determine MIME type based on the used options
            string mimeType = GetMimeTypeForFormat(format);
            Console.WriteLine($"MIME type: {mimeType}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to get MIME type based on format string
    private static string GetMimeTypeForFormat(string format)
    {
        if (format.Equals("PDF", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForDocumentOptions(new PdfSaveOptions());
        if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForDocumentOptions(new DocSaveOptions());
        if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForDocumentOptions(new XpsSaveOptions());

        // Image formats
        if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForImageFormat(ImageFormat.Jpeg);
        if (format.Equals("PNG", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForImageFormat(ImageFormat.Png);
        if (format.Equals("GIF", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForImageFormat(ImageFormat.Gif);
        if (format.Equals("BMP", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForImageFormat(ImageFormat.Bmp);
        if (format.Equals("TIFF", StringComparison.OrdinalIgnoreCase))
            return GetMimeTypeForImageFormat(ImageFormat.Tiff);

        return "application/octet-stream";
    }

    // Returns MIME type for document save options
    private static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is PdfSaveOptions)
            return "application/pdf";
        if (options is DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";

        return "application/octet-stream";
    }

    // Returns MIME type for image format
    private static string GetMimeTypeForImageFormat(ImageFormat format)
    {
        if (format == ImageFormat.Jpeg)
            return "image/jpeg";
        if (format == ImageFormat.Png)
            return "image/png";
        if (format == ImageFormat.Gif)
            return "image/gif";
        if (format == ImageFormat.Bmp)
            return "image/bmp";
        if (format == ImageFormat.Tiff)
            return "image/tiff";

        return "application/octet-stream";
    }

    // Converts MHTML (or HTML) to the specified format and returns the output path
    private static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"output_{format.ToLower()}");

        if (format.Equals("PDF", StringComparison.OrdinalIgnoreCase))
        {
            var options = new PdfSaveOptions();
            outputPath += ".pdf";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            var options = new DocSaveOptions();
            outputPath += ".docx";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            var options = new XpsSaveOptions();
            outputPath += ".xps";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Jpeg;
            var options = new ImageSaveOptions(imgFormat);
            outputPath += ".jpg";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("PNG", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Png;
            var options = new ImageSaveOptions(imgFormat);
            outputPath += ".png";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("GIF", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Gif;
            var options = new ImageSaveOptions(imgFormat);
            outputPath += ".gif";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("BMP", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Bmp;
            var options = new ImageSaveOptions(imgFormat);
            outputPath += ".bmp";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else if (format.Equals("TIFF", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Tiff;
            var options = new ImageSaveOptions(imgFormat);
            outputPath += ".tiff";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
        }
        else
        {
            throw new ArgumentException($"Unsupported format: {format}");
        }

        return outputPath;
    }
}