// Write the PDF output of ConvertHTML directly to a MemoryStream for further processing without creating a temporary file.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    public System.Collections.Generic.List<System.IO.MemoryStream> Streams { get; } = new System.Collections.Generic.List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (System.IO.MemoryStream ms in Streams)
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
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string baseUrl = "";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            CustomStreamProvider provider = new CustomStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            System.IO.MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;

            byte[] pdfBytes = pdfStream.ToArray();
            Console.WriteLine("PDF generated in memory. Size: {0} bytes.", pdfBytes.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}