// Store extracted images in memory streams for further processing before writing to disk.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
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
        try
        {
            string inputPath = "sample.epub";
            string outputDirectory = "output_images";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the EPUB file
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Configure image save options (PNG format)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                // Create the custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images, storing each image in a memory stream
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    // Process each generated image stream
                    int index = 0;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0; // Rewind before reading

                        // Example further processing: obtain byte array
                        byte[] imageBytes = ms.ToArray();

                        // Write the image to disk
                        string outputPath = Path.Combine(outputDirectory, $"image_{index}.png");
                        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            ms.CopyTo(fileStream);
                        }

                        index++;
                    }
                }
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}