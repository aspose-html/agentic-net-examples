// Implement logging of input EPUB metadata before conversion to assist in troubleshooting output GIF issues.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";

            // Ensure directories exist
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);

            string epubPath = System.IO.Path.Combine(dataDir, "sample.epub");
            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(epubPath))
            {
                System.IO.File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Log basic EPUB file metadata
            var fileInfo = new System.IO.FileInfo(epubPath);
            System.Console.WriteLine("EPUB File: " + fileInfo.FullName);
            System.Console.WriteLine("Size (bytes): " + fileInfo.Length);
            System.Console.WriteLine("Created: " + fileInfo.CreationTime);

            // Convert EPUB to GIF
            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(epubPath))
            {
                string outputPath = System.IO.Path.Combine(outputDir, "output.gif");
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                System.Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}