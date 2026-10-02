// Write the PDF output of ConvertHTML directly to a MemoryStream for further processing without creating a temporary file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

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
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            CustomStreamProvider provider = new CustomStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;

            byte[] pdfBytes = pdfStream.ToArray();
            System.Console.WriteLine("PDF generated in memory. Size: " + pdfBytes.Length + " bytes.");

            provider.Dispose();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}