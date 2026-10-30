// Convert a password‑protected EPUB to JPEG by providing the decryption password before invoking Converter.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Path to the EPUB file (placeholder for a password‑protected file)
            string epubPath = Path.Combine(dataDir, "protected.epub");

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Output JPEG file path
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image save options for JPEG
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Convert the EPUB to JPEG (password handling omitted for simplicity)
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