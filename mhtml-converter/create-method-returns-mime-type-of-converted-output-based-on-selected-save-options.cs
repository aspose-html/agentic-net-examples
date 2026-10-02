// Create a method that returns the MIME type of the converted output based on selected save options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            string format = "JPEG"; // Change to "XPS" or "DOCX" as needed
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            string mime;

            if (format == "JPEG")
            {
                mime = GetMimeTypeForImageFormat(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            }
            else if (format == "XPS")
            {
                mime = GetMimeTypeForDocumentOptions(new Aspose.Html.Saving.XpsSaveOptions());
            }
            else // DOCX
            {
                mime = GetMimeTypeForDocumentOptions(new Aspose.Html.Saving.DocSaveOptions());
            }

            Console.WriteLine($"Converted file: {outputPath}");
            Console.WriteLine($"MIME type: {mime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (format == "XPS")
        {
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            string outputPath = "output.xps";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else if (format == "DOCX")
        {
            var options = new Aspose.Html.Saving.DocSaveOptions();
            string outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else if (format == "JPEG")
        {
            var imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
            var options = new Aspose.Html.Saving.ImageSaveOptions(imageFormat);
            string outputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else
        {
            throw new ArgumentException("Unsupported format");
        }
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