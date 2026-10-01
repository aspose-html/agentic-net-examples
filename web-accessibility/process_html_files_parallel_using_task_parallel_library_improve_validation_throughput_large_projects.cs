// Process HTML files in parallel using Task Parallel Library to improve validation throughput for large projects.

using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "InputHtml";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingHtml = Directory.GetFiles(inputFolder, "*.html");
            if (existingHtml.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // 1. Convert each HTML file to JPEG image
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // 2. Merge two HTML files into one document
            string[] inputFiles = new string[]
            {
                Path.Combine(inputFolder, "sample.html"),
                Path.Combine(inputFolder, "sample2.html")
            };
            // Ensure second sample exists
            if (!File.Exists(inputFiles[1]))
            {
                File.WriteAllText(inputFiles[1], "<html><body><p>Second file content.</p></body></html>");
            }

            Aspose.Html.HTMLDocument mergedDocument = new Aspose.Html.HTMLDocument(
                "<html><head></head><body></body></html>");
            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                    continue;

                using (Aspose.Html.HTMLDocument sourceDocument = new Aspose.Html.HTMLDocument(filePath))
                {
                    Aspose.Html.HTMLElement container = (Aspose.Html.HTMLElement)mergedDocument.CreateElement("div");
                    container.InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;
                    mergedDocument.Body.AppendChild(container);
                }
            }
            string mergedPath = Path.Combine(outputFolder, "merged.html");
            mergedDocument.Save(mergedPath);
            mergedDocument.Dispose();

            // 3. Convert HTML files to PDF with network logging
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new LogHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
            }

            // 4. Extract HTML files from a zip archive (if zip exists)
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
            Directory.CreateDirectory(extractDir);
            if (File.Exists(zipPath))
            {
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
            }

            // 5. Convert extracted HTML to PDF with timeout handling
            Aspose.Html.Configuration configWithTimeout = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService netWithTimeout = configWithTimeout.GetService<Aspose.Html.Services.INetworkService>();
            netWithTimeout.MessageHandlers.Add(new TimeoutHandler());

            string[] extractedHtml = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (extractedHtml.Length > 0)
            {
                string htmlPath = extractedHtml[0];
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configWithTimeout))
                {
                    string pdfOut = Path.Combine(outputFolder, "extracted.pdf");
                    Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOut);
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Network request logger
class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

// Network timeout setter
class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}