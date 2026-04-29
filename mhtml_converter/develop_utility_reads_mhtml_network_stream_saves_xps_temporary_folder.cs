// Develop a utility that reads MHTML from a network stream and saves XPS to a temporary folder.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

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
        {
            stream.Position = 0;
        }
    }

    public void Dispose()
    {
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // URL of the MHTML document to download
            string url = "http://example.com/document.mhtml";

            // Download MHTML content as a stream
            using HttpClient client = new HttpClient();
            using Stream mhtmlStream = await client.GetStreamAsync(url);

            // Prepare XPS conversion options
            XpsSaveOptions options = new XpsSaveOptions();

            // Provider to capture the XPS output in memory
            using MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert MHTML stream to XPS, output captured by provider
            Converter.ConvertMHTML(mhtmlStream, options, provider);

            // Retrieve the generated XPS stream
            MemoryStream xpsStream = provider.Streams[0];
            xpsStream.Position = 0;

            // Create a temporary folder for the output file
            string tempFolder = Path.Combine(Path.GetTempPath(), "AsposeMhtmlXps");
            Directory.CreateDirectory(tempFolder);

            // Define the output XPS file path
            string outputPath = Path.Combine(tempFolder, "output.xps");

            // Write the XPS stream to the file system
            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                xpsStream.CopyTo(file);
            }

            Console.WriteLine($"XPS file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}