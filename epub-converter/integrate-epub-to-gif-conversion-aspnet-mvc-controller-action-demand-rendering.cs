// Integrate EPUB to GIF conversion into an ASP.NET MVC controller action for on‑demand rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Create a minimal placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(inputPath))
                {
                    // Placeholder content (empty)
                }
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to GIF successfully. Output: " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}