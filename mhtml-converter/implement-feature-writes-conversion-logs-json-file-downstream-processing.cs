// Implement a feature that writes conversion logs to a JSON file for downstream processing.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";
            string logPath = "conversion_log.json";

            // Ensure a minimal EPUB file exists.
            if (!File.Exists(inputPath))
            {
                CreateMinimalEpub(inputPath);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                MemoryStreamProvider provider = new MemoryStreamProvider();

                DateTime startTime = DateTime.UtcNow;
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
                DateTime endTime = DateTime.UtcNow;

                // Write first generated stream to output file.
                if (provider.Streams.Count > 0)
                {
                    MemoryStream firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    using (FileStream file = File.Create(outputPath))
                    {
                        firstStream.CopyTo(file);
                    }
                }

                // Prepare log entry.
                var logEntry = new
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    DurationMs = (endTime - startTime).TotalMilliseconds,
                    OutputFile = Path.GetFullPath(outputPath)
                };

                string json = JsonSerializer.Serialize(logEntry, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(logPath, json);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void CreateMinimalEpub(string path)
    {
        // Create a minimal EPUB (ZIP) structure.
        using (FileStream fs = new FileStream(path, FileMode.Create))
        using (System.IO.Compression.ZipArchive zip = new System.IO.Compression.ZipArchive(fs, System.IO.Compression.ZipArchiveMode.Create))
        {
            // mimetype file (must be first and uncompressed)
            var mimetypeEntry = zip.CreateEntry("mimetype", System.IO.Compression.CompressionLevel.NoCompression);
            using (var entryStream = mimetypeEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write("application/epub+zip");
            }

            // META-INF/container.xml
            var containerEntry = zip.CreateEntry("META-INF/container.xml");
            using (var entryStream = containerEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
  <rootfiles>
    <rootfile full-path=""OEBPS/content.opf"" media-type=""application/oebps-package+xml""/>
  </rootfiles>
</container>");
            }

            // OEBPS/content.opf
            var contentOpfEntry = zip.CreateEntry("OEBPS/content.opf");
            using (var entryStream = contentOpfEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""3.0"" unique-identifier=""BookId"">
  <metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"">
    <dc:identifier id=""BookId"">urn:uuid:12345</dc:identifier>
    <dc:title>Sample EPUB</dc:title>
    <dc:language>en</dc:language>
  </metadata>
  <manifest>
    <item id=""html"" href=""index.html"" media-type=""application/xhtml+xml""/>
  </manifest>
  <spine>
    <itemref idref=""html""/>
  </spine>
</package>");
            }

            // OEBPS/index.html
            var htmlEntry = zip.CreateEntry("OEBPS/index.html");
            using (var entryStream = htmlEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Sample</title></head>
<body><h1>Hello, EPUB!</h1></body>
</html>");
            }
        }
    }
}