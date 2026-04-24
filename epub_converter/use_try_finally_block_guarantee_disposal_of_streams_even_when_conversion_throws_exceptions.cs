// Use a try‑finally block to guarantee disposal of streams even when conversion throws exceptions.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomStreamProvider : ICreateStreamProvider, IDisposable
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
        if (stream != null) stream.Flush();
    }
    public void Dispose()
    {
        foreach (var ms in Streams) ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.xps";

            Stream stream = null;
            CustomStreamProvider provider = null;
            try
            {
                stream = File.OpenRead(inputPath);
                provider = new CustomStreamProvider();
                var options = new XpsSaveOptions();
                Converter.ConvertEPUB(stream, options, provider);
                var resultStream = provider.Streams[0];
                resultStream.Position = 0;
                using (var output = File.Create(outputPath))
                {
                    resultStream.CopyTo(output);
                }
            }
            finally
            {
                if (provider != null) provider.Dispose();
                if (stream != null) stream.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}