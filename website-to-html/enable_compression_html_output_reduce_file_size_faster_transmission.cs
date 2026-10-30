// Enable compression of the HTML output to reduce file size for faster transmission.

using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace AsposeHtmlExample
{
    public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(30);
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Define paths
                string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
                string extractDir = Path.Combine(Path.GetTempPath(), "sample_extracted");
                Directory.CreateDirectory(extractDir);

                // Create a sample HTML file and zip it if the zip does not exist
                if (!File.Exists(zipPath))
                {
                    string tempHtmlDir = Path.Combine(Path.GetTempPath(), "sample_html");
                    Directory.CreateDirectory(tempHtmlDir);
                    string sampleHtmlPath = Path.Combine(tempHtmlDir, "sample.html");
                    File.WriteAllText(sampleHtmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

                    using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(sampleHtmlPath, "sample.html");
                    }
                }

                // Extract HTML files from the zip
                using (FileStream zipStream = File.OpenRead(zipPath))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                        {
                            string entryPath = Path.Combine(extractDir, entry.FullName);
                            string entryFolder = Path.GetDirectoryName(entryPath);
                            if (!string.IsNullOrEmpty(entryFolder))
                                Directory.CreateDirectory(entryFolder);
                            entry.ExtractToFile(entryPath, true);
                        }
                    }
                }

                // Locate the extracted HTML file
                string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                    htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                    throw new FileNotFoundException("No HTML file found after ZIP extraction.");

                string htmlPath = htmlFiles[0];

                // Configure network service with timeout handler
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Insert(0, new TimeoutHandler());

                // Render HTML to PDF
                string pdfPath = Path.Combine(extractDir, "output.pdf");
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
                {
                    document.RenderTo(device);
                }

                // Convert HTML to TIFF image
                string tiffPath = Path.Combine(extractDir, "output.tiff");
                using (Aspose.Html.HTMLDocument imgDocument = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    options.BackgroundColor = Color.White;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertHTML(imgDocument, options, tiffPath);
                }

                Console.WriteLine("PDF saved to: " + pdfPath);
                Console.WriteLine("TIFF saved to: " + tiffPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}