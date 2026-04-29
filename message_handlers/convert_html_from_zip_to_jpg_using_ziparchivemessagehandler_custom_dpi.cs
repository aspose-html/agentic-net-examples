// Convert HTML from a ZIP archive to JPG using ZipArchiveMessageHandler with custom DPI option.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "input.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "HtmlFromZip");
            Directory.CreateDirectory(extractDir);

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

            string htmlPath = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories)[0];
            Configuration configuration = new Configuration();

            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
                options.HorizontalResolution = 150;
                options.VerticalResolution = 150;

                string outputPath = "output.jpg";
                ImageDevice device = new ImageDevice(options, outputPath);
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}