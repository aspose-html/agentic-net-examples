// Wrap the entire batch conversion loop in a try‑catch block to capture and log any unexpected errors.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;

class CustomStreamProvider : ICreateStreamProvider, IDisposable
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
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
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
            string inputDir = "InputEpubs";
            string outputDir = "OutputXps";
            Directory.CreateDirectory(outputDir);
            string[] files = Directory.GetFiles(inputDir, "*.epub");

            try
            {
                foreach (string inputPath in files)
                {
                    try
                    {
                        using (Stream stream = File.OpenRead(inputPath))
                        {
                            CustomStreamProvider streamProvider = new CustomStreamProvider();
                            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, streamProvider);
                            MemoryStream resultStream = streamProvider.Streams[0];
                            resultStream.Position = 0;
                            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                            using (Stream output = File.Create(outputPath))
                            {
                                resultStream.CopyTo(output);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error converting file " + Path.GetFileName(inputPath) + ": " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Batch conversion error: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}