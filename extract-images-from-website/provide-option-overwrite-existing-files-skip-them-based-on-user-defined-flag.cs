// Provide an option to overwrite existing files or skip them based on a user‑defined flag.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exists
            string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(sampleHtmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello Aspose.HTML</h1></body></html>";
                System.IO.File.WriteAllText(sampleHtmlPath, htmlContent);
            }

            // User‑defined flag: set to true to overwrite existing PDFs, false to skip them
            bool overwriteExisting = false;

            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(htmlPath);
                string outputPath = System.IO.Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                if (System.IO.File.Exists(outputPath) && !overwriteExisting)
                {
                    System.Console.WriteLine($"Skipping existing file: {outputPath}");
                    continue;
                }

                // Load the HTML document from file
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Configure PDF save options (default options are sufficient for this example)
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

                System.Console.WriteLine($"Converted: {htmlPath} -> {outputPath}");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}