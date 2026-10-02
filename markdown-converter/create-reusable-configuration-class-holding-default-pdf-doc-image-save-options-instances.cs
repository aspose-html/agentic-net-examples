// Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, and ImageSaveOptions instances.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

public static class SaveOptionsConfig
{
    public static readonly PdfSaveOptions PdfOptions = new PdfSaveOptions();

    public static readonly DocSaveOptions DocOptions = new DocSaveOptions();

    public static readonly ImageFormat DefaultImageFormat = ImageFormat.Png;

    public static readonly ImageSaveOptions ImageOptions = new ImageSaveOptions()
    {
        Format = DefaultImageFormat
    };
}

public static class MimeHelper
{
    public static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is PdfSaveOptions)
            return "application/pdf";
        if (options is DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    public static string GetMimeTypeForImageFormat(ImageFormat format)
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

public class Program
{
    public static void Main()
    {
        try
        {
            string pdfMime = MimeHelper.GetMimeTypeForDocumentOptions(SaveOptionsConfig.PdfOptions);
            string docMime = MimeHelper.GetMimeTypeForDocumentOptions(SaveOptionsConfig.DocOptions);
            string imgMime = MimeHelper.GetMimeTypeForImageFormat(SaveOptionsConfig.DefaultImageFormat);

            System.Console.WriteLine("PDF MIME type: " + pdfMime);
            System.Console.WriteLine("DOC MIME type: " + docMime);
            System.Console.WriteLine("Image MIME type: " + imgMime);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}