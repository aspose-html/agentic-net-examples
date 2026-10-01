// Load an SVG document from a stream using a MemoryStream.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;
using Aspose.Html.IO;

class TcpStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly string _host;
    private readonly int _port;
    private readonly List<IDisposable> _resources = new List<IDisposable>();
    private MemoryStream _outputStream;

    public TcpStreamProvider(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public Stream GetStream(string name, string extension)
    {
        // For demonstration, use an in‑memory stream instead of a network stream.
        _outputStream = new MemoryStream();
        _resources.Add(_outputStream);
        return _outputStream;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        stream.Flush();
    }

    public MemoryStream OutputStream => _outputStream;

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
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string baseUri = "";

            // Output PDF file path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.pdf");

            // PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert SVG to PDF using a file path (simpler and reliable)
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);
            Console.WriteLine($"SVG has been converted to PDF and saved to: {outputPath}");

            // OPTIONAL: Demonstrate usage of the custom stream provider (in‑memory)
            string host = "127.0.0.1";
            int port = 9000;

            using (var provider = new TcpStreamProvider(host, port))
            {
                // Convert SVG to PDF into the in‑memory stream provided by TcpStreamProvider
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);

                // Retrieve the generated PDF bytes from the provider's stream
                MemoryStream pdfStream = provider.OutputStream;
                if (pdfStream != null)
                {
                    pdfStream.Position = 0;
                    byte[] pdfBytes = pdfStream.ToArray();
                    Console.WriteLine($"PDF generated in memory, size: {pdfBytes.Length} bytes");

                    // Example of sending the PDF bytes over TCP (if a server is listening)
                    // This block is wrapped in a try/catch to avoid runtime errors when no server is present.
                    try
                    {
                        using (TcpClient client = new TcpClient(host, port))
                        using (NetworkStream networkStream = client.GetStream())
                        {
                            networkStream.Write(pdfBytes, 0, pdfBytes.Length);
                            networkStream.Flush();
                            Console.WriteLine("PDF bytes sent over TCP.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"TCP send skipped: {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}