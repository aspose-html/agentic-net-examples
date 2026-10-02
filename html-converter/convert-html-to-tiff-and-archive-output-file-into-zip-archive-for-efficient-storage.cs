// Convert HTML to TIFF and archive the output file into a ZIP archive for efficient storage.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string tiffPath = "output.tiff";
            string zipPath = "output.zip";

            // Create a minimal HTML file
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set up image save options for TIFF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, tiffPath);

            // Create ZIP archive containing the TIFF
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(tiffPath));
                using (Stream entryStream = entry.Open())
                using (FileStream fileStream = new FileStream(tiffPath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(entryStream);
                }
            }

            Console.WriteLine("HTML successfully converted to TIFF and archived to ZIP.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}