// Use a FileStream to write the XPS output directly to a network share with appropriate permissions.

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
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Set XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Create provider to capture output in memory
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert HTML to XPS using the provider
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, provider);

            // Retrieve the generated XPS stream
            MemoryStream xpsStream = provider.Streams[0];
            xpsStream.Position = 0;

            // Save XPS to a file for verification
            string outputPath = "output.xps";
            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                xpsStream.CopyTo(file);
            }

            Console.WriteLine($"Conversion completed successfully. XPS saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}