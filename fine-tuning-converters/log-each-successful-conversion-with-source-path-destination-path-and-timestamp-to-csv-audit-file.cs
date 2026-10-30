// Log each successful conversion with source path, destination path, and timestamp to a CSV audit file.

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
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
            string csvPath = "audit.csv";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            HashSet<string> processedFiles = new HashSet<string>();

            for (int iteration = 0; iteration < 5; iteration++)
            {
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
                foreach (string htmlPath in htmlFiles)
                {
                    if (processedFiles.Contains(htmlPath))
                        continue;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Convert HTML to JPEG image
                    HTMLDocument document = new HTMLDocument(htmlPath);
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    // Log conversion to CSV
                    using (StreamWriter csvWriter = new StreamWriter(csvPath, true))
                    {
                        string timestamp = DateTime.Now.ToString("o");
                        csvWriter.WriteLine($"{htmlPath},{outputPath},{timestamp}");
                    }

                    processedFiles.Add(htmlPath);
                }

                Thread.Sleep(200);
            }

            Console.WriteLine("Processing completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}