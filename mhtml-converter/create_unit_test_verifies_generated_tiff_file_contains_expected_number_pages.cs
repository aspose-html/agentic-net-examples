// Create a unit test that verifies the generated TIFF file contains the expected number of pages.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                CreateMinimalEpub(epubPath);
            }

            using (Stream stream = File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                MemoryStreamProvider provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, provider);

                int expectedPages = 1;
                int actualPages = provider.Streams.Count;

                if (actualPages != expectedPages)
                {
                    throw new InvalidOperationException($"Expected {expectedPages} page(s), but got {actualPages}.");
                }

                for (int i = 0; i < actualPages; i++)
                {
                    MemoryStream ms = provider.Streams[i];
                    ms.Position = 0;
                    string outputPath = $"page_{i + 1}.tiff";
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        ms.CopyTo(fileStream);
                    }
                }

                Console.WriteLine("TIFF conversion and page count verification passed.");
                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateMinimalEpub(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create))
        using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Create))
        {
            // mimetype (must be stored without compression)
            ZipArchiveEntry mimetypeEntry = archive.CreateEntry("mimetype", CompressionLevel.NoCompression);
            using (StreamWriter writer = new StreamWriter(mimetypeEntry.Open()))
            {
                writer.Write("application/epub+zip");
            }

            // META-INF/container.xml
            ZipArchiveEntry containerEntry = archive.CreateEntry("META-INF/container.xml");
            using (StreamWriter writer = new StreamWriter(containerEntry.Open()))
            {
                writer.Write(@"<?xml version=""1.0""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
  <rootfiles>
    <rootfile full-path=""OEBPS/content.opf"" media-type=""application/oebps-package+xml""/>
  </rootfiles>
</container>");
            }

            // OEBPS/content.opf
            ZipArchiveEntry contentOpfEntry = archive.CreateEntry("OEBPS/content.opf");
            using (StreamWriter writer = new StreamWriter(contentOpfEntry.Open()))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""3.0"" unique-identifier=""BookId"">
  <metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"">
    <dc:identifier id=""BookId"">urn:uuid:12345</dc:identifier>
    <dc:title>Sample Book</dc:title>
    <dc:language>en</dc:language>
  </metadata>
  <manifest>
    <item id=""chapter1"" href=""chapter1.html"" media-type=""application/xhtml+xml""/>
  </manifest>
  <spine>
    <itemref idref=""chapter1""/>
  </spine>
</package>");
            }

            // OEBPS/chapter1.html
            ZipArchiveEntry chapterEntry = archive.CreateEntry("OEBPS/chapter1.html");
            using (StreamWriter writer = new StreamWriter(chapterEntry.Open()))
            {
                writer.Write(@"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Chapter 1</title></head>
<body><h1>Chapter 1</h1><p>This is a sample page.</p></body>
</html>");
            }
        }
    }
}