// Batch process a JSON array of URLs, converting each to PDF and storing results in cloud storage.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

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
            string json = File.ReadAllText("urls.json");
            List<string> urls = JsonSerializer.Deserialize<List<string>>(json);
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            using var httpClient = new HttpClient();
            for (int i = 0; i < urls.Count; i++)
            {
                try
                {
                    string url = urls[i];
                    string htmlContent = httpClient.GetStringAsync(url).Result;
                    HTMLDocument document = new HTMLDocument(htmlContent, url);
                    PdfSaveOptions options = new PdfSaveOptions();
                    using var streamProvider = new CustomStreamProvider();
                    Converter.ConvertHTML(document, options, streamProvider);
                    MemoryStream memory = streamProvider.Streams[0];
                    memory.Position = 0;
                    string filePath = Path.Combine(outputDir, $"output_{i}.pdf");
                    using FileStream fs = File.Create(filePath);
                    memory.CopyTo(fs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing URL at index {i}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}