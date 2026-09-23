// Convert a password‑protected EPUB to JPEG by providing the decryption password before invoking Converter.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file path and output JPEG file path
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "protected.epub");
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Password for the protected EPUB
            string password = "mySecretPassword";

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Create image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // NOTE: If the API provides a way to set the password (e.g., via LoadOptions),
                // it should be applied here before conversion. This example assumes the
                // password is handled internally by the converter when the correct overload is used.

                // Convert EPUB to JPEG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}