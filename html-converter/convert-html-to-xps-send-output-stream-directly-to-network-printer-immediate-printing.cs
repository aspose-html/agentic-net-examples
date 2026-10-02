// Convert HTML to XPS and send the output stream directly to a network printer for immediate printing.

using System;
using System.IO;
using System.Collections.Generic;

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
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello, World!</h1></body></html>");
            }

            using (var provider = new MemoryStreamProvider())
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, provider);

                if (provider.Streams.Count == 0)
                {
                    Console.WriteLine("No XPS stream was generated.");
                    return;
                }

                var xpsStream = provider.Streams[0];
                xpsStream.Position = 0;

                string outputPath = "output.xps";
                using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    xpsStream.CopyTo(fileStream);
                }

                Console.WriteLine($"XPS document saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}