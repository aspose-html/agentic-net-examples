// Set PDF device options to embed fonts when rendering HTML from ZIP to PDF.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string zipPath = "input.zip";
            string extractDirectory = "extracted";
            string fontsFolder = "fonts";
            string outputPdfPath = "output.pdf";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

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

            // Locate the first extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML with custom fonts folder
            Configuration configuration = new Configuration();
            IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configuration
            using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
            {
                // Set PDF rendering options (fonts will be embedded automatically)
                PdfRenderingOptions pdfOptions = new PdfRenderingOptions();
                // Uncomment and adjust if explicit font embedding control is needed:
                // pdfOptions.FontEmbedding = Aspose.Html.Rendering.Pdf.FontEmbedding.Always;

                // Create PDF device with the options and render the document
                using (PdfDevice device = new PdfDevice(pdfOptions, outputPdfPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}