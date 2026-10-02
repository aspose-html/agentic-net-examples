// Clean up temporary files after conversion completes using a cleanup handler.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFolder = "InputHtml";
        string outputFolder = "OutputPdf";

        Directory.CreateDirectory(inputFolder);
        Directory.CreateDirectory(outputFolder);

        string htmlPath = Path.Combine(inputFolder, "sample.html");
        if (!File.Exists(htmlPath))
        {
            File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
        }

        string outputPath = Path.Combine(outputFolder, "sample.pdf");

        try
        {
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    MemoryStream resultStream = provider.streams[0];
                    resultStream.Position = 0;

                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}