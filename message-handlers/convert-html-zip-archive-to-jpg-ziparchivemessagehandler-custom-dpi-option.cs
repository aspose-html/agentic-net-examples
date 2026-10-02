// Convert HTML from a ZIP archive to JPG using ZipArchiveMessageHandler with custom DPI option.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "HTMLFromZip");
            System.IO.Directory.CreateDirectory(extractDir);

            // Extract HTML files from the ZIP archive
            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(entryPath));
                        using (System.IO.Stream source = entry.Open())
                        using (System.IO.FileStream destination = new System.IO.FileStream(entryPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            source.CopyTo(destination);
                        }
                    }
                }
            }

            // Locate the extracted HTML file
            string htmlPath = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories)[0];
            string outputPath = System.IO.Path.Combine(extractDir, "result.jpg");

            // Configure image save options with custom DPI
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}