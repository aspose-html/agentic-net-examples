// Implement a custom ICreateStreamProvider that writes PNG output to a network stream for remote storage.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                var provider = new NetworkStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                // Send each generated PNG stream to a remote server (example: localhost:5000)
                foreach (var ms in provider.Streams)
                {
                    ms.Position = 0;
                    using (var client = new TcpClient("localhost", 5000))
                    using (var networkStream = client.GetStream())
                    {
                        ms.CopyTo(networkStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

sealed class NetworkStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<System.IO.MemoryStream> _streams = new List<System.IO.MemoryStream>();
    public IReadOnlyList<System.IO.MemoryStream> Streams => _streams;

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
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