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

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            string sampleFilePath = System.IO.Path.Combine(inputFolder, "sample.mhtml");
            if (!System.IO.File.Exists(sampleFilePath))
            {
                System.IO.File.WriteAllText(sampleFilePath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            System.Collections.Generic.HashSet<string> processedFiles = new System.Collections.Generic.HashSet<string>();

            for (int i = 0; i < 5; i++)
            {
                string[] files = System.IO.Directory.GetFiles(inputFolder, "*.mhtml");
                foreach (string file in files)
                {
                    if (!processedFiles.Contains(file))
                    {
                        try
                        {
                            using (System.IO.FileStream stream = System.IO.File.OpenRead(file))
                            {
                                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                                string outputFileName = System.IO.Path.GetFileNameWithoutExtension(file) + ".gif";
                                string outputPath = System.IO.Path.Combine(outputFolder, outputFileName);
                                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                            }
                            processedFiles.Add(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing {file}: {ex.Message}");
                        }
                    }
                }
                System.Threading.Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}