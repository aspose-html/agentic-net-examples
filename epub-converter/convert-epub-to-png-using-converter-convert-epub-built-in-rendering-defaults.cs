// Convert an EPUB file to PNG using Converter.ConvertEPUB and rely on built‑in rendering defaults.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);

            string epubPath = System.IO.Path.Combine(dataDir, "sample.epub");
            string outputPath = System.IO.Path.Combine(outputDir, "output.png");

            // Create a minimal EPUB file if it does not exist
            if (!System.IO.File.Exists(epubPath))
            {
                System.IO.File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to PNG successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}