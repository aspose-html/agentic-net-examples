// Write a wrapper method that selects appropriate ImageSaveOptions based on the desired output image format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, "<html><body><h1>Sample</h1></body></html>");

            // Desired output image format
            string desiredFormat = "png"; // can be jpeg, png, gif, bmp, tiff

            // Create ImageSaveOptions based on format
            Aspose.Html.Saving.ImageSaveOptions options = CreateImageSaveOptions(desiredFormat);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to image
            string outputPath = "output." + desiredFormat;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Example usage of MIME type helpers
            string imageMime = GetMimeTypeForImageFormat(options.Format);
            Console.WriteLine($"Image saved to '{outputPath}' with MIME type: {imageMime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Aspose.Html.Saving.ImageSaveOptions CreateImageSaveOptions(string format)
    {
        Aspose.Html.Rendering.Image.ImageFormat imageFormat;
        switch (format?.Trim().ToLowerInvariant())
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

        return new Aspose.Html.Saving.ImageSaveOptions(imageFormat);
    }

    private static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";

        throw new ArgumentException("Unsupported document save options type.");
    }

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

        throw new ArgumentException("Unsupported image format.");
    }
}