// Render an EPUB to PDF with chapter titles as bookmarks for easy navigation in the output file.

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

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                using (var zip = new ZipArchive(File.Create(inputPath), ZipArchiveMode.Create))
                {
                    // mimetype file (required for EPUB)
                    var mimetypeEntry = zip.CreateEntry("mimetype");
                    using (var writer = new StreamWriter(mimetypeEntry.Open()))
                    {
                        writer.Write("application/epub+zip");
                    }

                    // Minimal container.xml
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

                    // Minimal content.opf
                    var contentOpfEntry = zip.CreateEntry("OEBPS/content.opf");
                    using (var writer = new StreamWriter(contentOpfEntry.Open()))
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

                    // Minimal chapter1.xhtml
                    var chapterEntry = zip.CreateEntry("OEBPS/chapter1.xhtml");
                    using (var writer = new StreamWriter(chapterEntry.Open()))
                    {
                        writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
  <head><title>Chapter 1</title></head>
  <body><h1>Hello, EPUB!</h1><p>This is a minimal EPUB file.</p></body>
</html>");
                    }
                }
            }

            using (var stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"EPUB successfully converted to PDF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}