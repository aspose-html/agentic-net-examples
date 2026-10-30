// Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputPdf";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md", SearchOption.TopDirectoryOnly);
            if (markdownFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a sample markdown file.");
                markdownFiles = new string[] { samplePath };
            }

            foreach (string markdownPath in markdownFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(markdownPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}