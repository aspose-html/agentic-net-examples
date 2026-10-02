// Use a FileStream to write the XPS output directly to a network share with appropriate permissions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MyStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            stream.Position = 0;
        }
    }

    public void Dispose()
    {
        foreach (MemoryStream s in Streams)
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

            // Set up XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Create stream provider to capture XPS output in memory
            using (MyStreamProvider provider = new MyStreamProvider())
            {
                // Convert HTML to XPS using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, provider);

                // Retrieve the generated XPS stream
                MemoryStream xpsStream = provider.Streams[0];
                xpsStream.Position = 0;

                // Define network share path (adjust as needed)
                string networkPath = @"\\NetworkShare\Output\output.xps";

                // Write XPS stream directly to the network share using FileStream
                using (FileStream fileStream = new FileStream(networkPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xpsStream.CopyTo(fileStream);
                }

                Console.WriteLine("XPS file successfully saved to network share: " + networkPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}