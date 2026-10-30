// Clean up temporary files after conversion completes using a cleanup handler.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams = new List<MemoryStream>();

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
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        string inputFolder = "InputHtml";
        string outputFolder = "OutputPdf";
        try
        {
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string htmlPath = Path.Combine(inputFolder, "sample.html");
            File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");

            string outputPath = Path.Combine(outputFolder, "sample.pdf");

            using (var document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                    if (provider.Streams.Count > 0)
                    {
                        var resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            resultStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            // Cleanup temporary HTML file
            if (File.Exists(htmlPath))
            {
                File.Delete(htmlPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}