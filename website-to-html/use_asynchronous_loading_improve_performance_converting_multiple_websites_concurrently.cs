// Use asynchronous loading to improve performance when converting multiple websites concurrently.

using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO.Compression;

public class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in‑memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare temporary working directory
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(tempDir);

            // 1. Navigate to a URL and print page text
            string url = "about:blank";
            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;
                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null
                            ? document.DocumentElement.TextContent
                            : string.Empty;
                        resetEvent.Set();
                    }
                };
                document.Navigate(url);
                resetEvent.WaitOne();
                Console.WriteLine("Navigated page text: " + htmlResult);
            }

            // 2. Prepare a dummy EPUB file
            string epubPath = Path.Combine(tempDir, "sample.epub");
            File.WriteAllBytes(epubPath, new byte[0]); // empty file for demo
            Stream stream = File.OpenRead(epubPath);
            Aspose.Html.Saving.XpsSaveOptions xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();

            // 3. Custom stream provider for conversion output
            CustomStreamProvider provider = new CustomStreamProvider();

            // 4. Convert EPUB to XPS (may fail with empty file, but we capture timing)
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, xpsOptions, provider);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ConvertEPUB failed (expected with dummy file): " + ex.Message);
            }
            sw.Stop();
            Console.WriteLine($"EPUB conversion elapsed: {sw.Elapsed}");

            // 5. Write first generated stream to file if any
            if (provider.Streams.Count > 0)
            {
                string outputXpsPath = Path.Combine(tempDir, "output.xps");
                using (var outFile = File.Create(outputXpsPath))
                {
                    provider.Streams[0].Position = 0;
                    provider.Streams[0].CopyTo(outFile);
                }
                Console.WriteLine("First XPS stream written to: " + outputXpsPath);
            }

            // 6. Create a simple HTML file and save with resource handling options
            string htmlFilePath = Path.Combine(tempDir, "sample.html");
            File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>");
            using (Aspose.Html.HTMLDocument htmlDoc = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Saving.HTMLSaveOptions htmlSaveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
                htmlSaveOptions.ResourceHandlingOptions.MaxHandlingDepth = 5;
                htmlSaveOptions.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;
                string savedHtmlPath = Path.Combine(tempDir, "saved.html");
                htmlDoc.Save(savedHtmlPath, htmlSaveOptions);
                Console.WriteLine("HTML saved to: " + savedHtmlPath);
            }

            // 7. Create a zip containing a target file
            string zipPath = Path.Combine(tempDir, "sample.zip");
            using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
            {
                var entry = archive.CreateEntry("target.txt");
                using (var entryStream = entry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write("Content inside zip");
                }
            }

            // 8. Extract specific entries from zip
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
            Directory.CreateDirectory(extractDir);
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("target.txt", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                        Console.WriteLine("Extracted: " + entryPath);
                    }
                }
            }

            // 9. Configure network timeout handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new TimeoutHandler());

            // 10. Load extracted HTML (we'll treat target.txt as HTML for demo)
            string htmlPath = Directory.GetFiles(extractDir, "target.txt", SearchOption.AllDirectories)[0];
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string pdfPath = Path.Combine(tempDir, "output.pdf");
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath);
                doc.RenderTo(device);
                Console.WriteLine("Rendered PDF to: " + pdfPath);
            }

            // 11. Create a document from a request message
            string requestUrl = "about:blank";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUrl);
            request.Timeout = TimeSpan.FromSeconds(10);
            using (Aspose.Html.HTMLDocument requestDoc = new Aspose.Html.HTMLDocument(request))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)requestDoc.DocumentElement).OuterHTML;
                Console.WriteLine("OuterHTML from request document: " + outerHtml);
            }

            // Cleanup
            provider.Dispose();
            stream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Custom timeout handler as required
    class TimeoutHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(15);
            Next(context);
        }
    }
}