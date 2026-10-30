// Write a wrapper method that selects appropriate ImageSaveOptions based on the desired output image format.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Desired output image format
            Aspose.Html.Rendering.Image.ImageFormat imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;

            // Create ImageSaveOptions with specific resolution
            Aspose.Html.Saving.ImageSaveOptions options = CreateImageSaveOptions(imageFormat, 300, 300);

            // Determine MIME type for the selected image format
            string mimeType = GetMimeTypeForImageFormat(imageFormat);
            Console.WriteLine($"Selected MIME type: {mimeType}");

            // Convert HTML to image
            string outputPath = "output.jpg";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine($"Image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to create ImageSaveOptions for a given format and resolution
    private static Aspose.Html.Saving.ImageSaveOptions CreateImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat format, int horizontalResolution, int verticalResolution)
    {
        Aspose.Html.Saving.ImageSaveOptions opts = new Aspose.Html.Saving.ImageSaveOptions(format);
        opts.HorizontalResolution = horizontalResolution;
        opts.VerticalResolution = verticalResolution;
        return opts;
    }

    // Returns MIME type for supported document save options
    private static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    // Returns MIME type for supported image formats
    private static string GetMimeTypeForImageFormat(Aspose.Html.Rendering.Image.ImageFormat format)
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