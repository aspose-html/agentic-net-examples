// Implement a custom ICreateStreamProvider that directs BMP conversion output to an encrypted file stream.

using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

public class EncryptedStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly string _outputDir;
    private readonly List<Stream> _streams = new List<Stream>();
    private readonly List<string> _files = new List<string>();
    private readonly byte[] _key = new byte[32];
    private readonly byte[] _iv = new byte[16];

    public EncryptedStreamProvider(string outputDir)
    {
        _outputDir = outputDir;
        for (int i = 0; i < _key.Length; i++) _key[i] = (byte)i;
        for (int i = 0; i < _iv.Length; i++) _iv[i] = (byte)(i + 1);
    }

    public Stream GetStream(string name, string extension)
    {
        return GetStreamInternal(name, extension, -1);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return GetStreamInternal(name, extension, page);
    }

    private Stream GetStreamInternal(string name, string extension, int page)
    {
        string fileName = page >= 0
            ? Path.Combine(_outputDir, $"{name}_page{page}.{extension}.enc")
            : Path.Combine(_outputDir, $"{name}.{extension}.enc");

        var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        _streams.Add(cryptoStream);
        _files.Add(fileName);
        return cryptoStream;
    }

    public void ReleaseStream(Stream stream)
    {
        stream.Flush();
    }

    public void Dispose()
    {
        foreach (var stream in _streams)
        {
            stream.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<string> CreatedFiles => _files.AsReadOnly();
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (var provider = new EncryptedStreamProvider(outputDir))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                using (var inputStream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
                }

                foreach (var file in provider.CreatedFiles)
                {
                    Console.WriteLine("Encrypted file created: " + file);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}