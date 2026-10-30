// Use MemoryStream to convert a Markdown string to PDF without creating intermediate files on disk.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main()
    {
        try
        {
            string markdown = "# Sample Title\n\nThis is a **markdown** document.\n\n- Item 1\n- Item 2";
            byte[] markdownBytes = Encoding.UTF8.GetBytes(markdown);
            MemoryStream htmlStream = new MemoryStream(markdownBytes);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlStream, "about:blank");
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            MemoryStreamProvider provider = new MemoryStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            using (FileStream file = File.Create("markdown_output.pdf"))
            {
                pdfStream.CopyTo(file);
            }
            Console.WriteLine("PDF conversion succeeded. Output saved to markdown_output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}