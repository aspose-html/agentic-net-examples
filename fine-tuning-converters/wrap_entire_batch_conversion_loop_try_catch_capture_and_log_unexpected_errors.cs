// Wrap the entire batch conversion loop in a try‑catch block to capture and log any unexpected errors.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
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
                            XpsSaveOptions options = new XpsSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, streamProvider);
                            MemoryStream resultStream = streamProvider.Streams[0];
                            resultStream.Position = 0;
                            using (Stream output = File.Create(Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".xps")))
                            {
                                resultStream.CopyTo(output);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error processing file " + Path.GetFileName(inputPath) + ": " + ex.Message);
                    }
                }
            }
            catch (Exception outerEx)
            {
                Console.WriteLine("Unexpected error during batch conversion: " + outerEx.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fatal error: " + ex.Message);
        }
    }
}