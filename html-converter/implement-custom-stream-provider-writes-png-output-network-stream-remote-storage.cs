// Implement a custom ICreateStreamProvider that writes PNG output to a network stream for remote storage.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

sealed class NetworkStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
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
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                {
                    // Create an empty placeholder EPUB file
                }
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.Format = ImageFormat.Png;

                NetworkStreamProvider provider = new NetworkStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                foreach (MemoryStream ms in provider.Streams)
                {
                    ms.Position = 0;
                    using (TcpClient client = new TcpClient("localhost", 9000))
                    {
                        using (NetworkStream network = client.GetStream())
                        {
                            ms.CopyTo(network);
                        }
                    }
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}