// Validate that the output BMP file size is greater than zero after conversion to ensure successful rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "input.md";
            string outputBmp = "output.bmp";

            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            Converter.ConvertHTML(document, options, outputBmp);

            FileInfo info = new FileInfo(outputBmp);
            if (info.Length > 0)
            {
                Console.WriteLine("BMP file created successfully. Size: " + info.Length);
            }
            else
            {
                Console.WriteLine("BMP file size is zero. Conversion may have failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}