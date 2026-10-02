// Develop a REST endpoint that receives SVG data and returns PDF using in‑memory conversion.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Sample SVG content
            const string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='3'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>Demo</text>
</svg>";

            const string baseUri = "about:blank";

            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, pdfOptions, provider);

                if (provider.Streams.Count == 0)
                {
                    Console.WriteLine("Conversion failed: no output stream was created.");
                    return;
                }

                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                const string outputPath = "output.pdf";
                using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(fileStream);
                }

                Console.WriteLine($"SVG successfully converted to PDF and saved at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}