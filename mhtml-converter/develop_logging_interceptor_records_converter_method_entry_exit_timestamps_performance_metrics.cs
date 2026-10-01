// Develop a logging interceptor that records Converter method entry and exit timestamps for performance metrics.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
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
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";

            // Ensure a placeholder input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream input = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                var provider = new MemoryStreamProvider();

                DateTime start = DateTime.Now;
                Aspose.Html.Converters.Converter.ConvertEPUB(input, options, provider);
                DateTime end = DateTime.Now;

                TimeSpan elapsed = end - start;
                Console.WriteLine($"Conversion took {elapsed.TotalMilliseconds} ms.");

                if (provider.Streams.Count > 0)
                {
                    var firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    using (FileStream file = File.Create(outputPath))
                    {
                        firstStream.CopyTo(file);
                    }
                    Console.WriteLine($"First output saved to {outputPath}");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}