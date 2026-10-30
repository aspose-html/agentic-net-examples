// Batch render a set of MHTML newsletters to PNG images for email preview generation.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input MHTML files
            string[] inputFiles = new string[] { "newsletter1.mhtml", "newsletter2.mhtml" };
            string outputDir = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create minimal sample MHTML files if they do not exist
            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                {
                    string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: Sample\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Sample Newsletter</h1><p>This is a test.</p></body></html>\r\n------=_NextPart_000_0000--";
                    File.WriteAllText(filePath, mhtmlContent);
                }
            }

            // Convert each MHTML file to PNG
            foreach (string inputPath in inputFiles)
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}