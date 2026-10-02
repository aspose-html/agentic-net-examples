// Implement ICreateStreamProvider to direct SVG conversion output into a network stream for remote storage.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class NetworkStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' /></svg>";
            string baseUri = "about:blank";
            string host = "127.0.0.1";
            int port = 9000;

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            using (NetworkStreamProvider provider = new NetworkStreamProvider(host, port))
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);
            }

            System.Console.WriteLine("SVG conversion completed and sent to remote storage.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}