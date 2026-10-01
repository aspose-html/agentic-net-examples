// Convert HTML from a ZIP archive to PDF using ZipArchiveMessageHandler with default settings.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string outputPdfPath = "output.pdf";

            // Extract the required HTML file from the ZIP archive
            string extractDir = Path.Combine(Path.GetTempPath(), "sample_extracted");
            Directory.CreateDirectory(extractDir);

            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("test.html", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the extracted HTML file
            string htmlPath = Directory.GetFiles(extractDir, "test.html", SearchOption.AllDirectories)[0];

            // Load the HTML document and render it to PDF
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}