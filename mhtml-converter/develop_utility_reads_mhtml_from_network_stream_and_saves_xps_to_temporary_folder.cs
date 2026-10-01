// Develop a utility that reads MHTML from a network stream and saves XPS to a temporary folder.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            // Sample MHTML content (minimal)
            string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Mon, 1 Jan 2024 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";

            // Simulate network stream using HttpClient (optional) - here we use MemoryStream directly
            using (var mhtmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(mhtmlContent)))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, options, provider);

                    if (provider.Streams.Count == 0)
                        throw new InvalidOperationException("No output streams were generated.");

                    var xpsStream = provider.Streams[0];
                    xpsStream.Position = 0;

                    string outputPath = Path.Combine(Path.GetTempPath(), "output.xps");
                    using (var fileStream = File.Create(outputPath))
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