// Batch convert HTML files to PDF with a progress callback to monitor conversion status.

namespace BatchHtmlToPdf
{
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
                var existingFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                if (existingFiles.Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                    string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(samplePath, sampleContent);
                }
                ConvertHtmlFilesInFolder(inputFolder, outputFolder);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ConvertHtmlFilesInFolder(string inputFolder, string outputFolder)
        {
            string[] files = System.IO.Directory.GetFiles(inputFolder, "*.html");
            int total = files.Length;
            for (int i = 0; i < total; i++)
            {
                string htmlPath = files[i];
                System.Console.WriteLine($"Converting ({i + 1}/{total}): {System.IO.Path.GetFileName(htmlPath)}");
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(htmlPath), ".pdf");
                    string pdfPath = System.IO.Path.Combine(outputFolder, pdfFileName);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
                System.Console.WriteLine("Done.");
            }
        }
    }
}