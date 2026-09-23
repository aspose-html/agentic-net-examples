// Convert EPUB to TIFF and archive all output files into a ZIP container to simplify file management.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputDir = "output";
            string zipPath = "output.zip";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (System.IO.Stream epubStream = System.IO.File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputDir);
            }

            if (File.Exists(zipPath))
                File.Delete(zipPath);

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(outputDir))
                {
                    zip.CreateEntryFromFile(file, Path.GetFileName(file));
                }
            }

            Console.WriteLine("Conversion and archiving completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}