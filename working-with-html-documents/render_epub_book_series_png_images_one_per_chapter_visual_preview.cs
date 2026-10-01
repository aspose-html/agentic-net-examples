// Render an EPUB book to a series of PNG images, one per chapter, for visual preview.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
}

class Program
{
    static void Main()
    {
        try
        {
            const string epubPath = "sample.epub";

            if (!File.Exists(epubPath))
            {
                CreateSampleEpub(epubPath);
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.White;

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 0;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outPath = $"page_{index}.png";
                        using (var fileStream = File.Create(outPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved {outPath}");
                        index++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateSampleEpub(string path)
    {
        using (FileStream fs = File.Create(path))
        using (var archive = new ZipArchive(fs, ZipArchiveMode.Create))
        {
            // mimetype (must be first and uncompressed)
            var mimetypeEntry = archive.CreateEntry("mimetype", CompressionLevel.NoCompression);
            using (var entryStream = mimetypeEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write("application/epub+zip");
            }

            // META-INF/container.xml
            var containerEntry = archive.CreateEntry("META-INF/container.xml");
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
            var opfEntry = archive.CreateEntry("OEBPS/content.opf");
            using (var entryStream = opfEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" unique-identifier=""BookId"" version=""3.0"">
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
            var chapterEntry = archive.CreateEntry("OEBPS/chapter1.xhtml");
            using (var entryStream = chapterEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>Chapter 1</title>
</head>
<body>
<h1>Hello, EPUB!</h1>
<p>This is a sample page.</p>
</body>
</html>");
            }
        }
    }
}