// Convert EPUB to BMP and send the bitmap data over a network stream using a custom response handler.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    private MemoryStream _firstStream;

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        if (_firstStream == null)
            _firstStream = ms;
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        if (_firstStream == null)
            _firstStream = ms;
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
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
    public MemoryStream FirstStream => _firstStream;
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a minimal EPUB file for demonstration
            string epubPath = Path.Combine(Path.GetTempPath(), "sample.epub");
            using (var zip = new System.IO.Compression.ZipArchive(File.Open(epubPath, FileMode.Create), System.IO.Compression.ZipArchiveMode.Update))
            {
                var mimetypeEntry = zip.CreateEntry("mimetype", System.IO.Compression.CompressionLevel.NoCompression);
                using (var entryStream = mimetypeEntry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write("application/epub+zip");
                }

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

                var contentOpfEntry = zip.CreateEntry("OEBPS/content.opf");
                using (var entryStream = contentOpfEntry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""3.0"" unique-identifier=""BookId"">
  <metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"">
    <dc:identifier id=""BookId"">urn:uuid:12345</dc:identifier>
    <dc:title>Sample EPUB</dc:title>
    <dc:language>en</dc:language>
  </metadata>
  <manifest>
    <item id=""chapter1"" href=""chapter1.xhtml"" media-type=""application/xhtml+xml""/>
  </manifest>
  <spine>
    <itemref idref=""chapter1""/>
  </spine>
</package>");
                }

                var chapterEntry = zip.CreateEntry("OEBPS/chapter1.xhtml");
                using (var entryStream = chapterEntry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
  <head><title>Chapter 1</title></head>
  <body><h1>Hello, EPUB!</h1><p>This is a sample page.</p></body>
</html>");
                }
            }

            // Open the EPUB file stream
            using (System.IO.Stream epubStream = System.IO.File.OpenRead(epubPath))
            {
                // Set image save options for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Create custom stream provider
                MemoryStreamProvider provider = new MemoryStreamProvider();

                // Convert EPUB to BMP images (one per page)
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                // Ensure at least one image was generated
                if (provider.Streams.Count == 0)
                {
                    Console.WriteLine("No images were generated from the EPUB.");
                    return;
                }

                // Get the first generated bitmap stream
                System.IO.MemoryStream firstImageStream = provider.FirstStream;
                firstImageStream.Position = 0;

                // Simulate sending bitmap data over a network stream
                using (System.IO.Stream networkStream = new System.IO.MemoryStream())
                {
                    firstImageStream.CopyTo(networkStream);
                    Console.WriteLine($"Sent {networkStream.Length} bytes of BMP data over the simulated network stream.");
                }

                // Cleanup provider resources
                provider.Dispose();
            }

            // Delete temporary EPUB file
            if (System.IO.File.Exists(epubPath))
                System.IO.File.Delete(epubPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}