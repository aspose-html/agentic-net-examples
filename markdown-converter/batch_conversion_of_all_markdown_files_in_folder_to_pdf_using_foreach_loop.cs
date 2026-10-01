// Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputPdf";

            if (!System.IO.Directory.Exists(inputFolder))
            {
                System.IO.Directory.CreateDirectory(inputFolder);
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.md");
                System.IO.File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a test.");
            }

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] markdownFiles = System.IO.Directory.GetFiles(inputFolder, "*.md", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string mdPath in markdownFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(mdPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + ".pdf");

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}