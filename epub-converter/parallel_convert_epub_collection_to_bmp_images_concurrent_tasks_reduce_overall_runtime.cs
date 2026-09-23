// Parallel convert a collection of EPUB documents to BMP images with concurrent tasks to reduce overall runtime.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            var epubFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            // Create placeholder EPUB files if they do not exist
            foreach (var file in epubFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]);
                }
            }

            var tasks = new List<Task>();

            foreach (var epubPath in epubFiles)
            {
                tasks.Add(Task.Run(() =>
                {
                    using (System.IO.Stream stream = System.IO.File.OpenRead(epubPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                        string outputFolder = Path.Combine("output", Path.GetFileNameWithoutExtension(epubPath));
                        Directory.CreateDirectory(outputFolder);
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputFolder);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}