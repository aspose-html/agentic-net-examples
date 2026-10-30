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
            string inputFolder = "Input";
            string outputFolder = "Output";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            var processedFiles = new HashSet<string>();

            // Create a sample MHTML file if none exists
            string samplePath = Path.Combine(inputFolder, "sample.mhtml");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "Dummy MHTML content");
            }

            for (int i = 0; i < 5; i++)
            {
                string[] files = Directory.GetFiles(inputFolder, "*.mhtml");
                foreach (var file in files)
                {
                    if (!processedFiles.Contains(file))
                    {
                        try
                        {
                            using (FileStream stream = File.OpenRead(file))
                            {
                                string fileName = Path.GetFileNameWithoutExtension(file);
                                string outputPath = Path.Combine(outputFolder, fileName + ".gif");

                                Aspose.Html.Saving.ImageSaveOptions options =
                                    new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                                Console.WriteLine($"Converted '{file}' to GIF at '{outputPath}'.");
                            }
                            processedFiles.Add(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error converting '{file}': {ex.Message}");
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unhandled exception: {e.Message}");
        }
    }
}