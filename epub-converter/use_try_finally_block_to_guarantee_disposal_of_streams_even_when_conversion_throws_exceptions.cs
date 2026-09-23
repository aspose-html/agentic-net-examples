// Use a try‑finally block to guarantee disposal of streams even when conversion throws exceptions.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class customStreamProvider : ICreateStreamProvider, IDisposable
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
            string inputPath = "sample.epub";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            Stream inputStream = null;
            customStreamProvider provider = null;
            try
            {
                inputStream = File.OpenRead(inputPath);
                provider = new customStreamProvider();
                XpsSaveOptions options = new XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;

                Stream outputStream = null;
                try
                {
                    outputStream = File.Create(outputPath);
                    resultStream.CopyTo(outputStream);
                }
                finally
                {
                    if (outputStream != null)
                    {
                        outputStream.Dispose();
                    }
                }
            }
            finally
            {
                if (provider != null)
                {
                    provider.Dispose();
                }
                if (inputStream != null)
                {
                    inputStream.Dispose();
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}