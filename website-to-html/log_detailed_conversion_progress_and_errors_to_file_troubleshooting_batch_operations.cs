// Log detailed conversion progress and errors to a file for troubleshooting batch operations.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Drawing;

public sealed class RequestTimingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch requestTimer = Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

public class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
        {
            ms.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // 1. Extract ZIP and convert first HTML to PDF with request timing handler
            string zipPath = "sample.zip";
            string extractDirectory = "extracted";
            string outputPdfPath = "output.pdf";

            Directory.CreateDirectory(extractDirectory);

            // Create a sample ZIP with a simple HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("index.html");
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("<html><body><h1>Hello from ZIP</h1></body></html>");
                    }
                }
            }

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

            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RequestTimingHandler());

            Stopwatch conversionTimer = Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");

            // 2. Convert SVG files to PNG images
            string inputFolder = "svg_input";
            string outputFolder = "svg_output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if none exist
            string[] existingSvg = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvg.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
                    "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // 3. Convert HTML files to PDF with request logging handler
            string htmlInputDir = "html_input";
            Directory.CreateDirectory(htmlInputDir);
            // Create a sample HTML file if none exist
            if (Directory.GetFiles(htmlInputDir, "*.html").Length == 0)
            {
                string sampleHtml = Path.Combine(htmlInputDir, "sample.html");
                File.WriteAllText(sampleHtml, "<html><body><p>Sample HTML for logging.</p></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(htmlInputDir, "*.html"))
            {
                Aspose.Html.Configuration cfg = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService net = cfg.GetService<Aspose.Html.Services.INetworkService>();
                net.MessageHandlers.Add(new LogHandler());

                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath, cfg))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    Aspose.Html.Saving.PdfSaveOptions opts = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(doc, opts, pdfPath);
                }
            }

            // 4. Simple XPath logging example
            string logPath = "log.txt";
            File.AppendAllText(logPath, "Log start" + Environment.NewLine);
            Aspose.Html.HTMLDocument docForXPath = new Aspose.Html.HTMLDocument("<html><body><img src='image1.png'/><img src='image2.png'/></body></html>");
            File.AppendAllText(logPath, "Document created" + Environment.NewLine);
            Aspose.Html.Dom.XPath.IXPathResult result = docForXPath.Evaluate("//img", docForXPath, docForXPath.CreateNSResolver(docForXPath), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            File.AppendAllText(logPath, "XPath evaluated" + Environment.NewLine);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                File.AppendAllText(logPath, img.Src + Environment.NewLine);
            }

            // 5. Convert EPUB files to XPS using custom stream provider
            string epubInputDir = "epub_input";
            string xpsOutputDir = "xps_output";
            Directory.CreateDirectory(epubInputDir);
            Directory.CreateDirectory(xpsOutputDir);
            // Note: No sample EPUB is created; conversion will be skipped if none found.
            string[] epubFiles = Directory.GetFiles(epubInputDir, "*.epub");
            foreach (string inputPath in epubFiles)
            {
                try
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        CustomStreamProvider streamProvider = new CustomStreamProvider();
                        Aspose.Html.Saving.XpsSaveOptions opts = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, opts, streamProvider);
                        if (streamProvider.Streams.Count > 0)
                        {
                            MemoryStream resultStream = streamProvider.Streams[0];
                            resultStream.Position = 0;
                            string outPath = Path.Combine(xpsOutputDir,
                                Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                            using (Stream output = File.Create(outPath))
                            {
                                resultStream.CopyTo(output);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to convert EPUB file " + Path.GetFileName(inputPath) + ": " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}