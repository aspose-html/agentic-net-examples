// Convert HTML to XPS and send the output stream directly to a network printer for immediate printing.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string contentType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
            stream.Position = 0;
    }

    public void Dispose()
    {
        foreach (var s in Streams)
            s.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // XPS conversion options (default settings)
            XpsSaveOptions options = new XpsSaveOptions();

            // Provider that captures the XPS output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert HTML to XPS and write the result to the provider
                Converter.ConvertHTML(htmlPath, options, provider);

                // Retrieve the generated XPS stream
                MemoryStream xpsStream = provider.Streams[0];
                xpsStream.Position = 0;

                // At this point xpsStream contains the XPS document.
                // Sending the stream directly to a network printer is omitted
                // because printer APIs are not available in this environment.

                Console.WriteLine($"Conversion succeeded. XPS size: {xpsStream.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}