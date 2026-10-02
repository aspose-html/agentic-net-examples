// Use a try‑finally block to guarantee disposal of streams even when conversion throws exceptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputXps";
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);
            string[] files = Directory.GetFiles(inputDir, "*.epub");
            foreach (string inputPath in files)
            {
                try
                {
                    Stream inputStream = null;
                    MemoryStreamProvider provider = null;
                    try
                    {
                        inputStream = File.OpenRead(inputPath);
                        provider = new MemoryStreamProvider();
                        XpsSaveOptions options = new XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
                        MemoryStream resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                        using (Stream output = File.Create(outputPath))
                        {
                            resultStream.CopyTo(output);
                        }
                    }
                    finally
                    {
                        if (provider != null) provider.Dispose();
                        if (inputStream != null) inputStream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing " + Path.GetFileName(inputPath) + ": " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fatal error: " + ex.Message);
        }
    }
}