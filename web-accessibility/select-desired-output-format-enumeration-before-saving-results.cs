// Select the desired output format by using the ValidationResultSaveFormat enumeration before saving results.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file
            string inputMhtmlPath = "sample.mht";
            if (!File.Exists(inputMhtmlPath))
            {
                // Simple MHTML content (HTML wrapped in MIME format)
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: Mon, 01 Jan 2024 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputMhtmlPath, mhtmlContent);
            }

            // Convert to desired format
            string format = "JPEG"; // Change to "XPS" or "DOCX" as needed
            string outputPath = ConvertMhtmlByFormat(inputMhtmlPath, format);
            Console.WriteLine($"Conversion completed. Output file: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (string.IsNullOrEmpty(inputPath))
            throw new ArgumentException("Input path is null or empty.", nameof(inputPath));

        if (string.IsNullOrEmpty(format))
            throw new ArgumentException("Format is null or empty.", nameof(format));

        string upperFormat = format.Trim().ToUpperInvariant();
        string outputPath;

        switch (upperFormat)
        {
            case "XPS":
                {
                    var options = new Aspose.Html.Saving.XpsSaveOptions();
                    outputPath = Path.ChangeExtension(inputPath, ".xps");
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
                    break;
                }
            case "DOCX":
                {
                    var options = new Aspose.Html.Saving.DocSaveOptions();
                    outputPath = Path.ChangeExtension(inputPath, ".docx");
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
                    break;
                }
            case "JPEG":
                {
                    var imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                    var options = new Aspose.Html.Saving.ImageSaveOptions(imageFormat);
                    outputPath = Path.ChangeExtension(inputPath, ".jpg");
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
                    break;
                }
            default:
                throw new NotSupportedException($"The format '{format}' is not supported.");
        }

        // Optionally, you can retrieve MIME type using helpers
        // string mime = GetMimeTypeForDocumentOptions(options);
        // Console.WriteLine($"MIME type: {mime}");

        return outputPath;
    }

    static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    static string GetMimeTypeForImageFormat(Aspose.Html.Rendering.Image.ImageFormat format)
    {
        if (format == Aspose.Html.Rendering.Image.ImageFormat.Jpeg)
            return "image/jpeg";
        if (format == Aspose.Html.Rendering.Image.ImageFormat.Png)
            return "image/png";
        if (format == Aspose.Html.Rendering.Image.ImageFormat.Gif)
            return "image/gif";
        if (format == Aspose.Html.Rendering.Image.ImageFormat.Bmp)
            return "image/bmp";
        if (format == Aspose.Html.Rendering.Image.ImageFormat.Tiff)
            return "image/tiff";
        return "application/octet-stream";
    }
}