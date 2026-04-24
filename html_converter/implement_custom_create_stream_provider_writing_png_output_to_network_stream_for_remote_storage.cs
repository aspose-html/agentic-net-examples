// Implement a custom ICreateStreamProvider that writes PNG output to a network stream for remote storage.

using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class NetworkStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _host;
    private readonly int _port;

    public NetworkStreamProvider(string host, int port)
    {
        _host = host;
        _port = port;
    }

    // Called by Aspose.HTML to obtain a stream for each output page.
    public Stream GetStream(string path, string mimeType)
    {
        var client = new TcpClient(_host, _port);
        // Return the network stream; Aspose will write PNG bytes into it.
        return client.GetStream();
    }

    // Overload with page index (not used in this simple implementation).
    public Stream GetStream(string path, string mimeType, int pageIndex)
    {
        return GetStream(path, mimeType);
    }

    // Called after writing is finished; close the network stream.
    public void ReleaseStream(Stream stream)
    {
        stream?.Dispose();
    }

    public void Dispose()
    {
        // No unmanaged resources to clean up in this simple provider.
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file.
            const string epubPath = "sample.epub";

            // Open the EPUB file as a read‑only stream.
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options (default format is PNG).
                ImageSaveOptions options = new ImageSaveOptions();

                // Create the custom provider that writes PNG data to a remote server.
                // Replace "example.com" and 12345 with actual host and port.
                ICreateStreamProvider provider = new NetworkStreamProvider("example.com", 12345);

                // Perform the conversion; each page image will be sent over the network.
                Converter.ConvertEPUB(epubStream, options, provider);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}