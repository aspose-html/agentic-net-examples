// Set PDF device options to embed fonts when rendering HTML from ZIP to PDF.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string zipPath = "sample.zip";
            string extractDirectory = "extracted";
            string fontsFolder = "fonts";
            string outputPdfPath = "output.pdf";

            // Ensure required directories exist
            Directory.CreateDirectory(fontsFolder);
            Directory.CreateDirectory(extractDirectory);

            // Create a sample ZIP archive with a simple HTML file
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                ZipArchiveEntry entry = archive.CreateEntry("test.html");
                using (StreamWriter writer = new StreamWriter(entry.Open()))
                {
                    writer.Write("<html><body><p>Hello World</p></body></html>");
                }
            }

            // Extract HTML files from the ZIP archive
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDirectory, entry.FullName);
                        string entryFolder = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Initialize Aspose.Html configuration and set custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load HTML document from extracted file
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            // Create PDF device and render
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}