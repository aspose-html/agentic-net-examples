// Log each successful conversion with source path, destination path, and timestamp to a CSV audit file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";
            string csvPath = "conversion_audit.csv";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            if (!File.Exists(csvPath))
            {
                using (StreamWriter headerWriter = new StreamWriter(csvPath, false))
                {
                    headerWriter.WriteLine("SourcePath,DestinationPath,Timestamp");
                }
            }

            HashSet<string> processedFiles = new HashSet<string>();

            for (int iteration = 0; iteration < 5; iteration++)
            {
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
                foreach (string htmlPath in htmlFiles)
                {
                    if (processedFiles.Contains(htmlPath))
                        continue;

                    try
                    {
                        HTMLDocument document = new HTMLDocument(htmlPath);
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                        string outputFileName = Path.GetFileNameWithoutExtension(htmlPath) + ".jpg";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                        string timestamp = DateTime.Now.ToString("o");
                        using (StreamWriter csvWriter = new StreamWriter(csvPath, true))
                        {
                            csvWriter.WriteLine($"{htmlPath},{outputPath},{timestamp}");
                        }

                        processedFiles.Add(htmlPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing '{htmlPath}': {ex.Message}");
                    }
                }

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}