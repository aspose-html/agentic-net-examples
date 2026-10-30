// Develop a REST endpoint that receives SVG data and returns PDF using in‑memory conversion.

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
        // No action needed
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static byte[] ConvertSvgToPdf(string svgContent)
    {
        string baseUri = "about:blank";
        var options = new PdfSaveOptions();
        using (var provider = new MemoryStreamProvider())
        {
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);
            var pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            return pdfStream.ToArray();
        }
    }

    static void Main()
    {
        try
        {
            string sampleSvg = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            byte[] pdfBytes = ConvertSvgToPdf(sampleSvg);
            string outputPath = "output.pdf";
            File.WriteAllBytes(outputPath, pdfBytes);
            Console.WriteLine($"PDF generated successfully. Size: {pdfBytes.Length} bytes. Saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}