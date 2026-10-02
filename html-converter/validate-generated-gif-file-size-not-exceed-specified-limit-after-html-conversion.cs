// Validate that generated GIF file size does not exceed a specified limit after HTML conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            string outputPath = "output.gif";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            long fileSize = new System.IO.FileInfo(outputPath).Length;
            long maxSize = 50000; // maximum allowed size in bytes

            if (fileSize <= maxSize)
            {
                Console.WriteLine($"GIF size {fileSize} bytes is within the limit of {maxSize} bytes.");
            }
            else
            {
                Console.WriteLine($"GIF size {fileSize} bytes exceeds the limit of {maxSize} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}