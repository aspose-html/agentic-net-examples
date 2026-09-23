// Implement logging of input EPUB metadata before conversion to assist in troubleshooting output GIF issues.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.gif";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                var fileInfo = new System.IO.FileInfo(inputPath);
                System.Console.WriteLine($"EPUB Path: {inputPath}");
                System.Console.WriteLine($"Size: {fileInfo.Length} bytes");
                System.Console.WriteLine($"Created: {fileInfo.CreationTime}");
                System.Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");

                using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                    System.Console.WriteLine($"Conversion completed. GIF saved to {outputPath}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}