// Provide an option to overwrite existing files or skip them based on a user‑defined flag.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            bool overwrite = true; // Set to false to skip existing PDF files

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Hello Aspose</h1></body></html>");
            }

            ConvertHtmlFilesInFolder(inputFolder, overwrite);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlFilesInFolder(string folderPath, bool overwrite)
    {
        string[] htmlFiles = Directory.GetFiles(folderPath, "*.html");
        foreach (string htmlPath in htmlFiles)
        {
            string outputPath = Path.ChangeExtension(htmlPath, ".pdf");

            if (File.Exists(outputPath) && !overwrite)
            {
                Console.WriteLine($"Skipping existing file: {outputPath}");
                continue;
            }

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Converted: {outputPath}");
        }
    }
}