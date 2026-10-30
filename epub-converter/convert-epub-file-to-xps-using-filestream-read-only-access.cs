// Convert an EPUB file to XPS by reading the source via FileStream with read‑only access.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
    static void Main()
    {
        string inputPath = "sample.epub";
        string outputPath = "output.xps";

        try
        {
            // Ensure input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Create, FileAccess.Write))
                {
                    // Write minimal placeholder content
                    byte[] placeholder = new byte[] { 0x50, 0x4B, 0x03, 0x04 }; // ZIP header (EPUB is a zip)
                    fs.Write(placeholder, 0, placeholder.Length);
                }
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            resultStream.CopyTo(outputFile);
                        }
                        Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
                    }
                    else
                    {
                        Console.WriteLine("No output streams were generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}