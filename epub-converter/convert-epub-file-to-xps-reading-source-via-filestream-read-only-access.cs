// Convert an EPUB file to XPS by reading the source via FileStream with read‑only access.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.epub";
        string outputPath = "output.xps";

        try
        {
            using (Stream stream = File.OpenRead(inputPath))
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                XpsSaveOptions options = new XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}