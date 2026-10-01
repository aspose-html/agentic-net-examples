// Convert EPUB to TIFF with SHA1 hash verification against a pre‑computed reference to ensure integrity.

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Update))
                {
                    // mimetype (must be stored without compression)
                    var mimetypeEntry = archive.CreateEntry("mimetype", CompressionLevel.NoCompression);
                    using (var entryStream = mimetypeEntry.Open())
                    using (var writer = new StreamWriter(entryStream, Encoding.UTF8))
                    {
                        writer.Write("application/epub+zip");
                    }

                    // META-INF/container.xml
                    var containerEntry = archive.CreateEntry("META-INF/container.xml");
                    using (var entryStream = containerEntry.Open())
                    using (var writer = new StreamWriter(entryStream, Encoding.UTF8))
                    {
                        writer.Write(@"<?xml version=""1.0""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
  <rootfiles>
    <rootfile full-path=""OEBPS/content.opf"" media-type=""application/oebps-package+xml""/>
  </rootfiles>
</container>");
                    }

                    // OEBPS/content.opf
                    var contentOpfEntry = archive.CreateEntry("OEBPS/content.opf");
                    using (var entryStream = contentOpfEntry.Open())
                    using (var writer = new StreamWriter(entryStream, Encoding.UTF8))
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
                    var chapterEntry = archive.CreateEntry("OEBPS/chapter1.xhtml");
                    using (var entryStream = chapterEntry.Open())
                    using (var writer = new StreamWriter(entryStream, Encoding.UTF8))
                    {
                        writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
    <title>Chapter 1</title>
  </head>
  <body>
    <h1>Hello, EPUB!</h1>
    <p>This is a minimal EPUB file for conversion.</p>
  </body>
</html>");
                    }
                }
            }

            // Open EPUB stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 600),
                    new Margin(0, 0, 0, 0));

                // Convert EPUB to TIFF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Compute SHA-1 hash of the generated TIFF
            byte[] outputBytes = File.ReadAllBytes(outputPath);
            string hashString;
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(outputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                hashString = sb.ToString();
            }

            // Pre‑computed reference hash (replace with actual expected value)
            string referenceHash = "replace_with_actual_sha1_hash";

            // Output results
            Console.WriteLine("Output TIFF path: " + outputPath);
            Console.WriteLine("SHA-1 hash: " + hashString);
            Console.WriteLine("Hash matches reference: " + (hashString.Equals(referenceHash, StringComparison.OrdinalIgnoreCase) ? "Yes" : "No"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}