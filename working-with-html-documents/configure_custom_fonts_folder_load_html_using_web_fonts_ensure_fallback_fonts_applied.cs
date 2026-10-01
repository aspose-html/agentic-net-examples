// Configure custom fonts folder, load HTML using web fonts, and ensure fallback fonts are applied.

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
            string extractDirectory = "extracted";
            string fontsFolder = "fonts";
            string outputPdfPath = "output.pdf";

            // Ensure fonts folder exists (can be empty for this example)
            Directory.CreateDirectory(fontsFolder);

            // Create a minimal zip with an HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                Directory.CreateDirectory(extractDirectory);
                string sampleHtmlPath = Path.Combine(extractDirectory, "sample.html");
                File.WriteAllText(sampleHtmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

                using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(sampleHtmlPath, "sample.html");
                }

                // Clean up the temporary HTML file
                File.Delete(sampleHtmlPath);
            }

            // Extract HTML files from the zip
            Directory.CreateDirectory(extractDirectory);
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
                        {
                            Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Find the first HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");
            }

            // Configure Aspose.HTML with custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(outputPdfPath));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}