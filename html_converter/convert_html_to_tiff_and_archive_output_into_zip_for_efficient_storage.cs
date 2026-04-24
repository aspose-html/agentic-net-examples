// Convert HTML to TIFF and archive the output file into a ZIP archive for efficient storage.

using System;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for source HTML, intermediate TIFF, and final ZIP archive
            string htmlPath = "input.html";
            string tiffPath = "output.tiff";
            string zipPath = "output.zip";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set up image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert HTML to TIFF
            Converter.ConvertHTML(document, options, tiffPath);

            // Create a ZIP archive and add the generated TIFF file
            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(tiffPath, System.IO.Path.GetFileName(tiffPath));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}