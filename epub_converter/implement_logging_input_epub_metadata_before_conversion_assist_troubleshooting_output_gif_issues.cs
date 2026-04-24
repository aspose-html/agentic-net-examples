// Implement logging of input EPUB metadata before conversion to assist in troubleshooting output GIF issues.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.gif";

            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Log EPUB metadata (content.opf)
                using (var zip = new ZipArchive(stream, ZipArchiveMode.Read, true))
                {
                    var entry = zip.GetEntry("content.opf") ??
                                zip.Entries.FirstOrDefault(e => e.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase));

                    if (entry != null)
                    {
                        using (var entryStream = entry.Open())
                        using (var reader = new StreamReader(entryStream))
                        {
                            string opfContent = reader.ReadToEnd();
                            Console.WriteLine("EPUB metadata (content.opf):");
                            Console.WriteLine(opfContent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Metadata file not found in EPUB.");
                    }
                }

                // Reset stream position for conversion
                stream.Position = 0;

                // Convert EPUB to GIF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine($"Conversion completed. GIF saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}