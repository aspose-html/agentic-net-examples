// Create a method that returns the MIME type of the converted output based on selected save options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Dummy MHTML content");
            }

            string outputPath = ConvertMhtmlByFormat(inputPath, "JPEG");
            Console.WriteLine("Converted file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath;
        if (string.Equals(format, "XPS", StringComparison.OrdinalIgnoreCase))
        {
            var options = new XpsSaveOptions();
            outputPath = Path.ChangeExtension(inputPath, ".xps");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            Console.WriteLine("MIME type: " + GetMimeTypeForDocumentOptions(options));
        }
        else if (string.Equals(format, "DOCX", StringComparison.OrdinalIgnoreCase))
        {
            var options = new DocSaveOptions();
            outputPath = Path.ChangeExtension(inputPath, ".docx");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            Console.WriteLine("MIME type: " + GetMimeTypeForDocumentOptions(options));
        }
        else if (string.Equals(format, "JPEG", StringComparison.OrdinalIgnoreCase))
        {
            ImageFormat imgFormat = ImageFormat.Jpeg;
            var options = new ImageSaveOptions(imgFormat);
            outputPath = Path.ChangeExtension(inputPath, ".jpg");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            Console.WriteLine("MIME type: " + GetMimeTypeForImageFormat(imgFormat));
        }
        else
        {
            throw new ArgumentException("Unsupported format: " + format);
        }

        return outputPath;
    }

    static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is PdfSaveOptions)
            return "application/pdf";
        if (options is DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    static string GetMimeTypeForImageFormat(ImageFormat format)
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
}