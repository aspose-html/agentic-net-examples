// Select the desired output format by using the ValidationResultSaveFormat enumeration before saving results.

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
            // Prepare a minimal HTML file to act as input (simulating MHTML)
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Sample Content</h1></body></html>");
            }

            // Convert to XPS
            string xpsResult = ConvertMhtmlByFormat(inputPath, "XPS");
            Console.WriteLine("XPS output: " + xpsResult);

            // Convert to DOCX
            string docxResult = ConvertMhtmlByFormat(inputPath, "DOCX");
            Console.WriteLine("DOCX output: " + docxResult);

            // Convert to JPEG
            string jpegResult = ConvertMhtmlByFormat(inputPath, "JPEG");
            Console.WriteLine("JPEG output: " + jpegResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        // Load the document (treating the input as HTML/MHTML)
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

        string outputPath;
        if (string.Equals(format, "XPS", StringComparison.OrdinalIgnoreCase))
        {
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            outputPath = "output.xps";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        else if (string.Equals(format, "DOCX", StringComparison.OrdinalIgnoreCase))
        {
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        else if (string.Equals(format, "JPEG", StringComparison.OrdinalIgnoreCase))
        {
            Aspose.Html.Rendering.Image.ImageFormat imgFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(imgFormat);
            outputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        else
        {
            throw new ArgumentException("Unsupported format: " + format);
        }

        return Path.GetFullPath(outputPath);
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