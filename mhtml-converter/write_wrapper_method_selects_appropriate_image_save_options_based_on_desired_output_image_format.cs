// Write a wrapper method that selects appropriate ImageSaveOptions based on the desired output image format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output image paths
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Choose desired image format
            string desiredFormat = "jpeg"; // can be jpeg, png, gif, bmp, tiff

            // Get ImageSaveOptions and the selected ImageFormat
            Aspose.Html.Rendering.Image.ImageFormat imageFormat;
            Aspose.Html.Saving.ImageSaveOptions options = GetImageSaveOptions(desiredFormat, out imageFormat);

            // Example of using MIME type helper
            string imageMime = GetMimeTypeForImageFormat(imageFormat);
            Console.WriteLine($"Selected image MIME type: {imageMime}");

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Wrapper method to create ImageSaveOptions based on format string
    static Aspose.Html.Saving.ImageSaveOptions GetImageSaveOptions(string format, out Aspose.Html.Rendering.Image.ImageFormat imageFormat)
    {
        switch (format.ToLowerInvariant())
        {
            case "jpeg":
            case "jpg":
                imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                break;
            case "png":
                imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Png;
                break;
            case "gif":
                imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Gif;
                break;
            case "bmp":
                imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Bmp;
                break;
            case "tiff":
            case "tif":
                imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Tiff;
                break;
            default:
                throw new ArgumentException($"Unsupported image format: {format}");
        }

        Aspose.Html.Saving.ImageSaveOptions opts = new Aspose.Html.Saving.ImageSaveOptions(imageFormat);
        // Set common options (example values)
        opts.HorizontalResolution = 96;
        opts.VerticalResolution = 96;
        return opts;
    }

    // Helper to get MIME type for document save options
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

    // Helper to get MIME type for image format
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