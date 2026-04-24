// Implement a custom ICreateStreamProvider that directs BMP conversion output to an encrypted file stream.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class EncryptedStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private readonly List<Stream> _streams = new List<Stream>();
    private readonly Aes _aes;

    public EncryptedStreamProvider(string outputPath, byte[] key, byte[] iv)
    {
        _outputPath = outputPath;
        _key = key;
        _iv = iv;
        _aes = Aes.Create();
        _aes.Key = _key;
        _aes.IV = _iv;
    }

    public Stream GetStream(string path, string extension)
    {
        return CreateEncryptedStream();
    }

    public Stream GetStream(string path, string extension, int pageNumber)
    {
        return CreateEncryptedStream();
    }

    private Stream CreateEncryptedStream()
    {
        var fileStream = new FileStream(_outputPath, FileMode.Create, FileAccess.Write);
        var cryptoStream = new CryptoStream(fileStream, _aes.CreateEncryptor(), CryptoStreamMode.Write);
        _streams.Add(cryptoStream);
        return cryptoStream;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
            stream.Dispose();
            _streams.Remove(stream);
        }
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s?.Dispose();
        }
        _streams.Clear();
        _aes?.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file
            using (Stream epubStream = File.OpenRead("sample.epub"))
            {
                // BMP image save options
                var options = new ImageSaveOptions(ImageFormat.Bmp);

                // Encryption key and IV (example values, replace with secure ones)
                byte[] key = new byte[32]; // 256-bit key
                byte[] iv = new byte[16];  // 128-bit IV
                // For demonstration, fill with zeros; in real scenarios, use a secure random key/iv
                Array.Clear(key, 0, key.Length);
                Array.Clear(iv, 0, iv.Length);

                // Provider that writes encrypted BMP to a file
                using (var provider = new EncryptedStreamProvider("encrypted_output.bmp", key, iv))
                {
                    Converter.ConvertEPUB(epubStream, options, provider);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}