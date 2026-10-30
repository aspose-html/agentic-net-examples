// Develop a utility that reads MHTML from a network stream and saves XPS to a temporary folder.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using Aspose.Html.IO;

class MyStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
    static void Main()
    {
        try
        {
            // URL of the MHTML document (replace with a valid MHTML URL if needed)
            string mhtmlUrl = "https://example.com/sample.mht";

            using (HttpClient httpClient = new HttpClient())
            using (Stream mhtmlStream = httpClient.GetStreamAsync(mhtmlUrl).Result)
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                using (var provider = new MyStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, options, provider);

                    if (provider.Streams.Count == 0)
                        throw new InvalidOperationException("No XPS stream was generated.");

                    MemoryStream xpsStream = provider.Streams[0];
                    xpsStream.Position = 0;

                    string tempFolder = Path.GetTempPath();
                    string outputPath = Path.Combine(tempFolder, "output.xps");

                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        xpsStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"XPS file saved to: {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}