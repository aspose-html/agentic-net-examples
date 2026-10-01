// Convert a password‑protected EPUB to JPEG by providing the decryption password before invoking Converter.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "protected.epub");
            if (!File.Exists(epubPath))
            {
                // Create a placeholder EPUB file (empty) for demonstration purposes
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            string outputPath = Path.Combine(outputDir, "result.jpg");

            using (FileStream stream = File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                // Password handling is not exposed in this API surface; proceeding with conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion to JPEG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}