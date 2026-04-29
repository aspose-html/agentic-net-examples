// Implement ICreateStreamProvider to direct SVG conversion output into a network stream for remote storage.

using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class NetworkStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _host;
    private readonly int _port;
    private readonly List<IDisposable> _resources = new List<IDisposable>();

    public NetworkStreamProvider(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public Stream GetStream(string name, string extension)
    {
        TcpClient client = new TcpClient(_host, _port);
        _resources.Add(client);
        Stream stream = client.GetStream();
        _resources.Add(stream);
        return stream;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        stream.Flush();
    }

    public void Dispose()
    {
        for (int i = _resources.Count - 1; i >= 0; i--)
        {
            _resources[i].Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // SVG markup to be converted
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='blue'/></svg>";
            // Base URI for resolving relative resources
            string baseUri = "http://example.com/";

            // Remote server details
            string host = "remote.server.com";
            int port = 9000;

            // PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert SVG to PDF and send the output to the remote network stream
            using (NetworkStreamProvider provider = new NetworkStreamProvider(host, port))
            {
                Converter.ConvertSVG(svgContent, baseUri, options, provider);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}