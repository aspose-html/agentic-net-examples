// Verify that the Converter object releases unmanaged resources by checking memory usage after multiple conversions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            int iterations = 10;
            for (int i = 0; i < iterations; i++)
            {
                long before = GC.GetTotalMemory(true);

                using (CustomStreamProvider provider = new CustomStreamProvider())
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, provider);
                    // Optionally, access the generated stream to ensure it's created
                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream result = provider.Streams[0];
                        result.Position = 0;
                        // Discard the content; just read length to ensure stream is usable
                        long length = result.Length;
                    }
                }

                long after = GC.GetTotalMemory(true);
                Console.WriteLine($"Iteration {i + 1}: Memory before = {before} bytes, after = {after} bytes, diff = {after - before} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}