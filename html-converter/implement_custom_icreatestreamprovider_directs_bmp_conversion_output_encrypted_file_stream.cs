// Implement a custom ICreateStreamProvider that directs BMP conversion output to an encrypted file stream.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string encryptedOutputPath = "encrypted_output.bin";

            if (!File.Exists(inputPath))
            {
                CreateMinimalEpub(inputPath);
            }

            var provider = new EncryptedStreamProvider();

            var options = new ImageSaveOptions(ImageFormat.Bmp);

            using (var inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
            }

            using (var combined = new MemoryStream())
            {
                foreach (var ms in provider.Streams)
                {
                    ms.Position = 0;
                    ms.CopyTo(combined);
                }

                byte[] plainBytes = combined.ToArray();

                byte[] key = new byte[32];
                byte[] iv = new byte[16];
                for (int i = 0; i < key.Length; i++) key[i] = (byte)i;
                for (int i = 0; i < iv.Length; i++) iv[i] = (byte)(i + 1);

                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    using (var fileStream = new FileStream(encryptedOutputPath, FileMode.Create, FileAccess.Write))
                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    }
                }
            }

            Console.WriteLine("Conversion and encryption completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CreateMinimalEpub(string path)
    {
        using (var fs = new FileStream(path, FileMode.Create))
        using (var archive = new ZipArchive(fs, ZipArchiveMode.Create))
        {
            var mimetypeEntry = archive.CreateEntry("mimetype", CompressionLevel.NoCompression);
            using (var entryStream = mimetypeEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write("application/epub+zip");
            }

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

            var contentOpfEntry = archive.CreateEntry("OEBPS/content.opf");
            using (var entryStream = contentOpfEntry.Open())
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

            var chapterEntry = archive.CreateEntry("OEBPS/chapter1.xhtml");
            using (var entryStream = chapterEntry.Open())
            using (var writer = new StreamWriter(entryStream))
            {
                writer.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Chapter 1</title></head>
<body><h1>Hello, EPUB!</h1><p>This is a sample page.</p></body>
</html>");
            }
        }
    }
}

class EncryptedStreamProvider : ICreateStreamProvider, IDisposable
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
    }
}