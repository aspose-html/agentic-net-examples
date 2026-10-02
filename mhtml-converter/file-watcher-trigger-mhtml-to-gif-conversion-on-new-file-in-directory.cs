// Implement a file watcher that triggers MHTML to GIF conversion whenever a new file appears in a directory.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            HashSet<string> processedFiles = new HashSet<string>();

            for (int i = 0; i < 5; i++)
            {
                string[] files = Directory.GetFiles(inputFolder, "*.mhtml");
                foreach (string filePath in files)
                {
                    if (processedFiles.Contains(filePath))
                        continue;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".gif");

                    using (FileStream stream = File.OpenRead(filePath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    }

                    processedFiles.Add(filePath);
                }

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}