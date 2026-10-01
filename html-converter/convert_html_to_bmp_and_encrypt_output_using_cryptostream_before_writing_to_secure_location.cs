// Convert HTML to BMP and encrypt the output using CryptoStream before writing to a secure location.

using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Dom;

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
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            string htmlContent = "<html><body><h1>Hello, BMP!</h1></body></html>";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count == 0)
                {
                    throw new InvalidOperationException("No output stream was generated.");
                }

                MemoryStream bmpStream = provider.Streams[0];
                bmpStream.Position = 0;

                // Generate encryption key and IV
                byte[] key = new byte[32]; // 256-bit key
                byte[] iv = new byte[16];  // 128-bit IV
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                    rng.GetBytes(iv);
                }

                string encryptedPath = Path.Combine(outputDir, "encrypted_output.bin");
                using (FileStream fileStream = File.Create(encryptedPath))
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        bmpStream.CopyTo(cryptoStream);
                    }
                }

                // Optionally, save key and IV for decryption (not required for this example)
                Console.WriteLine("Encryption completed. Encrypted file saved to: " + encryptedPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}