// Create a method that returns the MIME type of the converted output based on selected save options.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace AsposeHtmlMimeDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var pdfOptions = new PdfSaveOptions();
                var mimePdf = GetMimeTypeForDocumentOptions(pdfOptions);
                Console.WriteLine($"PDF MIME: {mimePdf}");

                var imgFormat = ImageFormat.Jpeg;
                var mimeImg = GetMimeTypeForImageFormat(imgFormat);
                Console.WriteLine($"Image MIME: {mimeImg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string GetMimeTypeForDocumentOptions(object options)
        {
            if (options is PdfSaveOptions) return "application/pdf";
            if (options is DocSaveOptions) return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            if (options is XpsSaveOptions) return "application/vnd.ms-xpsdocument";
            return "application/octet-stream";
        }

        static string GetMimeTypeForImageFormat(ImageFormat format)
        {
            if (format == ImageFormat.Jpeg) return "image/jpeg";
            if (format == ImageFormat.Png) return "image/png";
            if (format == ImageFormat.Gif) return "image/gif";
            if (format == ImageFormat.Bmp) return "image/bmp";
            if (format == ImageFormat.Tiff) return "image/tiff";
            return "application/octet-stream";
        }
    }
}