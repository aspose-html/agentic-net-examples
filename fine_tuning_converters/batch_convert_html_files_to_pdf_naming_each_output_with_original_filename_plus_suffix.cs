// Batch convert HTML files to PDF, naming each output file with the original filename plus a suffix.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputPdf";
            string suffix = "_converted";

            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string htmlContent = File.ReadAllText(htmlPath);
                string baseUri = Path.GetDirectoryName(htmlPath) ?? "";

                HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
                PdfSaveOptions options = new PdfSaveOptions();

                CustomStreamProvider streamProvider = new CustomStreamProvider();
                Converter.ConvertHTML(document, options, streamProvider);

                MemoryStream memory = streamProvider.Streams[0];
                memory.Position = 0;

                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(htmlPath) + suffix + ".pdf");

                using (FileStream fs = File.Create(outputPath))
                {
                    memory.CopyTo(fs);
                }

                document.Dispose();
                streamProvider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class CustomStreamProvider : ICreateStreamProvider, IDisposable
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