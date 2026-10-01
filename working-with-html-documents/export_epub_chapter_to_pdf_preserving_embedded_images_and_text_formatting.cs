// Export an EPUB chapter to PDF, preserving embedded images and text formatting.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            if (!File.Exists(inputPath))
            {
                CreateMinimalEpub(inputPath);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"EPUB converted to PDF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CreateMinimalEpub(string path)
    {
        using (var zip = new ZipArchive(File.Create(path), ZipArchiveMode.Create))
        {
            // mimetype (must be first and uncompressed)
            var mimetypeEntry = zip.CreateEntry("mimetype", CompressionLevel.NoCompression);
            using (var writer = new StreamWriter(mimetypeEntry.Open()))
            {
                writer.Write("application/epub+zip");
            }

            // META-INF/container.xml
            var containerEntry = zip.CreateEntry("META-INF/container.xml");
            using (var writer = new StreamWriter(containerEntry.Open()))
            {
                writer.Write(@"<?xml version=""1.0""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
  <rootfiles>
    <rootfile full-path=""OEBPS/content.opf"" media-type=""application/oebps-package+xml""/>
  </rootfiles>
</container>");
            }

            // OEBPS/content.opf
            var contentOpf = zip.CreateEntry("OEBPS/content.opf");
            using (var writer = new StreamWriter(contentOpf.Open()))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" unique-identifier=""BookId"" version=""3.0"">
  <metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"">
    <dc:identifier id=""BookId"">urn:uuid:12345</dc:identifier>
    <dc:title>Sample EPUB</dc:title>
    <dc:language>en</dc:language>
  </metadata>
  <manifest>
    <item id=""html"" href=""chapter1.html"" media-type=""application/xhtml+xml""/>
  </manifest>
  <spine>
    <itemref idref=""html""/>
  </spine>
</package>");
            }

            // OEBPS/chapter1.html
            var chapterEntry = zip.CreateEntry("OEBPS/chapter1.html");
            using (var writer = new StreamWriter(chapterEntry.Open()))
            {
                writer.Write(@"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Chapter 1</title></head>
<body><h1>Hello EPUB</h1><p>This is a sample EPUB file.</p></body>
</html>");
            }
        }
    }
}