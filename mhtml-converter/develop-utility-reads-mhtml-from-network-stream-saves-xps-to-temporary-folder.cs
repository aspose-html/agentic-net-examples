// Develop a utility that reads MHTML from a network stream and saves XPS to a temporary folder.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MhtmlToXpsStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        foreach (MemoryStream ms in Streams)
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
            // Simulate reading MHTML from a network stream
            string mhtmlContent = "<html><body><h1>Sample MHTML Content</h1></body></html>";
            byte[] mhtmlBytes = System.Text.Encoding.UTF8.GetBytes(mhtmlContent);
            using (MemoryStream networkStream = new MemoryStream(mhtmlBytes))
            {
                // Prepare XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Create custom stream provider to capture XPS output in memory
                using (MhtmlToXpsStreamProvider provider = new MhtmlToXpsStreamProvider())
                {
                    // Convert MHTML stream to XPS using the provider
                    Aspose.Html.Converters.Converter.ConvertMHTML(networkStream, options, provider);

                    // Retrieve the generated XPS stream
                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream xpsStream = provider.Streams[0];
                        xpsStream.Position = 0;

                        // Determine temporary output path
                        string tempFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
                        System.IO.Directory.CreateDirectory(tempFolder);
                        string outputPath = System.IO.Path.Combine(tempFolder, "output.xps");

                        // Write XPS bytes to file
                        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            xpsStream.CopyTo(fileStream);
                        }

                        Console.WriteLine("XPS file saved to: " + outputPath);
                    }
                    else
                    {
                        Console.WriteLine("No XPS stream was generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}