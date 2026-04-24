// Validate that generated GIF file size does not exceed a specified limit after HTML conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToGifValidator
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourceHtmlPath = "input.html";
                string outputGifPath = "output.gif";
                long maxSizeBytes = 500 * 1024;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceHtmlPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputGifPath);

                FileInfo fileInfo = new FileInfo(outputGifPath);
                if (fileInfo.Length > maxSizeBytes)
                {
                    throw new Exception($"Generated GIF size {fileInfo.Length} exceeds limit of {maxSizeBytes} bytes.");
                }

                Console.WriteLine("GIF generated successfully within size limit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}