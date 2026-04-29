// Use a FileStream to write the XPS output directly to a network share with appropriate permissions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

    public Stream GetStream(string name, string contentType)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string contentType, int bufferSize)
    {
        MemoryStream msPage = new MemoryStream();
        Streams.Add(msPage);
        return msPage;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Position = 0;
        }
    }

    public void Dispose()
    {
        foreach (MemoryStream s in Streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = @"C:\Path\To\Input.html";

            // XPS conversion options
            XpsSaveOptions options = new XpsSaveOptions();

            // Provider that captures the XPS output in memory
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert HTML to XPS, output is captured by the provider
            Converter.ConvertHTML(htmlPath, options, provider);

            // Retrieve the generated XPS stream
            MemoryStream xpsStream = provider.Streams[0];
            xpsStream.Position = 0;

            // Network share path where the XPS file will be saved
            string networkPath = @"\\ServerName\Share\Output.xps";

            // Write the XPS stream directly to the network share using FileStream
            using (FileStream fileStream = new FileStream(networkPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xpsStream.CopyTo(fileStream);
            }

            // Clean up
            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}