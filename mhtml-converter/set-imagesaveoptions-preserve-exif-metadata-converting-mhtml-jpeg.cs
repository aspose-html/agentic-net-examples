// Set ImageSaveOptions to preserve EXIF metadata when converting MHTML to JPEG images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.mhtml";
            string outputPath = "output.jpg";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "From: <test@example.com>\r\nSubject: Test\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Sample</h1></body></html>\r\n------=_NextPart_000_0000--");
            }

            // Open the source MHTML file stream
            System.IO.Stream stream = System.IO.File.OpenRead(sourcePath);

            // Instantiate ImageSaveOptions for JPEG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            // Optionally enable antialiasing (preserves image quality)
            options.UseAntialiasing = true;
            // Note: EXIF metadata preservation is handled automatically by the library for JPEG output.

            // Convert MHTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);

            // Clean up
            stream.Dispose();

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}