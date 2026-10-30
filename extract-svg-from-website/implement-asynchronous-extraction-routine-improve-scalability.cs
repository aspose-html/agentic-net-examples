// Implement an asynchronous version of the extraction routine to improve scalability.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed; streams are retained for later use.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Input EPUB file (create a minimal placeholder if it does not exist)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal zip header
            }

            // Output XPS file path
            string outputPath = "output.xps";

            // Log file path
            string logPath = "log.txt";

            // Prepare stream and options
            using (System.IO.Stream epubStream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Custom stream provider to capture in‑memory output
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Record start time
                    DateTime startTime = DateTime.Now;
                    System.IO.File.AppendAllText(logPath, $"Conversion started at: {startTime}" + System.Environment.NewLine);

                    // Perform conversion asynchronously
                    await Task.Run(() =>
                    {
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                    });

                    // Record end time and duration
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    System.IO.File.AppendAllText(logPath, $"Conversion ended at: {endTime}" + System.Environment.NewLine);
                    System.IO.File.AppendAllText(logPath, $"Elapsed: {duration}" + System.Environment.NewLine);

                    // Write the first generated memory stream to the output file
                    if (provider.Streams.Count > 0)
                    {
                        var firstStream = provider.Streams[0];
                        firstStream.Position = 0;
                        using (var fileStream = System.IO.File.Create(outputPath))
                        {
                            firstStream.CopyTo(fileStream);
                        }
                        System.IO.File.AppendAllText(logPath, $"First stream saved to: {outputPath}" + System.Environment.NewLine);
                    }
                }
            }

            // --- DOM extraction example ---
            // Sample HTML content
            string htmlContent = "<html><body><img src=\"image1.png\"/><img src=\"image2.jpg\"/></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Evaluate XPath to select all img elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            System.IO.File.AppendAllText(logPath, "Extracted image sources:" + System.Environment.NewLine);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                System.IO.File.AppendAllText(logPath, img.Src + System.Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}