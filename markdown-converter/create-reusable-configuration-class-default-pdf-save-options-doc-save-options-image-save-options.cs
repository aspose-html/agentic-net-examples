// Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, and ImageSaveOptions instances.

using System;

class SaveOptionsConfig
{
    public static readonly Aspose.Html.Saving.PdfSaveOptions PdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

    public static readonly Aspose.Html.Saving.DocSaveOptions DocOptions = new Aspose.Html.Saving.DocSaveOptions();

    public static readonly Aspose.Html.Saving.ImageSaveOptions ImageOptions = CreateDefaultImageSaveOptions();

    private static Aspose.Html.Saving.ImageSaveOptions CreateDefaultImageSaveOptions()
    {
        var options = new Aspose.Html.Saving.ImageSaveOptions();
        options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
        return options;
    }
}

static class MimeHelper
{
    public static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    public static string GetMimeTypeForImageFormat(Aspose.Html.Rendering.Image.ImageFormat format)
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

class Program
{
    static void Main()
    {
        try
        {
            var pdfOptions = SaveOptionsConfig.PdfOptions;
            var docOptions = SaveOptionsConfig.DocOptions;
            var imageOptions = SaveOptionsConfig.ImageOptions;
            var imageFormat = imageOptions.Format;

            string pdfMime = MimeHelper.GetMimeTypeForDocumentOptions(pdfOptions);
            string docMime = MimeHelper.GetMimeTypeForDocumentOptions(docOptions);
            string imgMime = MimeHelper.GetMimeTypeForImageFormat(imageFormat);

            System.Console.WriteLine($"PDF MIME type: {pdfMime}");
            System.Console.WriteLine($"DOCX MIME type: {docMime}");
            System.Console.WriteLine($"Image MIME type: {imgMime}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}