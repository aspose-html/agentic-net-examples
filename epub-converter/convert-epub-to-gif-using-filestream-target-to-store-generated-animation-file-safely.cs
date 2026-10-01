// Convert EPUB to GIF using a FileStream target to store the generated animation file safely.

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
                using (System.IO.FileStream fs = System.IO.File.Create(inputPath))
                {
                    // Minimal placeholder content; real EPUB required for actual conversion.
                }
            }

            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to GIF successfully. Output: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}