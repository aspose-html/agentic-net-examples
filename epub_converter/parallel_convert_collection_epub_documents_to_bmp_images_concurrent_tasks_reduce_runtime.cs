// Parallel convert a collection of EPUB documents to BMP images with concurrent tasks to reduce overall runtime.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace EpubToBmpParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var epubFiles = new List<string>
                {
                    "book1.epub",
                    "book2.epub",
                    "book3.epub"
                };

                var tasks = new List<Task>();
                foreach (var epubPath in epubFiles)
                {
                    tasks.Add(Task.Run(() => ConvertEpubToBmp(epubPath)));
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertEpubToBmp(string epubPath)
        {
            var outputPath = Path.ChangeExtension(epubPath, ".bmp");
            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
    }
}