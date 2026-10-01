// Load an SVG from a memory stream and convert it directly to BMP using ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal EPUB file
            string epubPath = Path.Combine(Path.GetTempPath(), "sample.epub");
            CreateMinimalEpub(epubPath);

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    byte[] imageBytes = firstStream.ToArray();

                    string outputPath = Path.Combine(Path.GetTempPath(), "output.bmp");
                    File.WriteAllBytes(outputPath, imageBytes);
                    Console.WriteLine($"Image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No image streams were generated.");
                }

                provider.Dispose();
            }

            // Clean up temporary EPUB file
            File.Delete(epubPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateMinimalEpub(string path)
    {
        if (File.Exists(path))
            File.Delete(path);

        using (var zip = new ZipArchive(File.Open(path, FileMode.CreateNew), ZipArchiveMode.Update))
        {
            // mimetype (must be first and uncompressed)
            var mimetypeEntry = zip.CreateEntry("mimetype", CompressionLevel.NoCompression);
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
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""3.0"" unique-identifier=""BookId"">
  <metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"">
    <dc:identifier id=""BookId"">urn:uuid:12345</dc:identifier>
    <dc:title>Sample Book</dc:title>
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

            // OEBPS/chapter1.xhtml
            var chapterEntry = zip.CreateEntry("OEBPS/chapter1.xhtml");
            using (var entryStream = chapterEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Chapter 1</title></head>
<body><h1>Hello EPUB</h1><p>This is a sample EPUB content.</p></body>
</html>");
            }
        }
    }
}

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

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
        // No action needed; keep streams for later reading.
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