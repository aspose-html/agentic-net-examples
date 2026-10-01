// Convert HTML from a ZIP archive to JPG using ZipArchiveMessageHandler with custom DPI option.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "HtmlFromZip");
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from the zip archive
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the extracted HTML file
            string htmlPath = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories)[0];
            string outputPath = "output.jpg";

            // Configure image save options with custom DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}