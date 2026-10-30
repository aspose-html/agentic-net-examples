// Create a command‑line utility that accepts EPUB input path and GIF output path as arguments.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.epub";
            string outputPath = args.Length > 1 ? args[1] : "output.gif";

            if (!File.Exists(inputPath))
            {
                CreateMinimalEpub(inputPath);
                Console.WriteLine($"Created minimal EPUB at '{inputPath}'.");
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"EPUB converted to GIF successfully. Output: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateMinimalEpub(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create, leaveOpen: false))
        {
            // mimetype (must be first entry, uncompressed)
            ZipArchiveEntry mimetypeEntry = zip.CreateEntry("mimetype", CompressionLevel.NoCompression);
            using (StreamWriter writer = new StreamWriter(mimetypeEntry.Open()))
            {
                writer.Write("application/epub+zip");
            }

            // META-INF/container.xml
            ZipArchiveEntry containerEntry = zip.CreateEntry("META-INF/container.xml");
            using (StreamWriter writer = new StreamWriter(containerEntry.Open()))
            {
                writer.Write(@"<?xml version='1.0'?>
<container version='1.0' xmlns='urn:oasis:names:tc:opendocument:xmlns:container'>
  <rootfiles>
    <rootfile full-path='OEBPS/content.opf' media-type='application/oebps-package+xml'/>
  </rootfiles>
</container>");
            }

            // OEBPS/content.opf
            ZipArchiveEntry contentOpfEntry = zip.CreateEntry("OEBPS/content.opf");
            using (StreamWriter writer = new StreamWriter(contentOpfEntry.Open()))
            {
                writer.Write(@"<?xml version='1.0' encoding='utf-8'?>
<package xmlns='http://www.idpf.org/2007/opf' version='3.0' unique-identifier='BookId'>
  <metadata xmlns:dc='http://purl.org/dc/elements/1.1/'>
    <dc:identifier id='BookId'>urn:uuid:12345</dc:identifier>
    <dc:title>Sample Book</dc:title>
    <dc:language>en</dc:language>
  </metadata>
  <manifest>
    <item id='chapter1' href='chapter1.xhtml' media-type='application/xhtml+xml'/>
  </manifest>
  <spine>
    <itemref idref='chapter1'/>
  </spine>
</package>");
            }

            // OEBPS/chapter1.xhtml
            ZipArchiveEntry chapterEntry = zip.CreateEntry("OEBPS/chapter1.xhtml");
            using (StreamWriter writer = new StreamWriter(chapterEntry.Open()))
            {
                writer.Write(@"<?xml version='1.0' encoding='utf-8'?>
<html xmlns='http://www.w3.org/1999/xhtml'>
  <head><title>Chapter 1</title></head>
  <body><h1>Hello EPUB</h1><p>This is a sample EPUB content.</p></body>
</html>");
            }
        }
    }
}