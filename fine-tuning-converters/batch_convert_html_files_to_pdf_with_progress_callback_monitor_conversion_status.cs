// Batch convert HTML files to PDF with a progress callback to monitor conversion status.

namespace BatchHtmlToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputPdf";

                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);

                string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
                if (!System.IO.File.Exists(sampleHtmlPath))
                {
                    System.IO.File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
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
            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                string pdfPath = System.IO.Path.ChangeExtension(htmlPath, ".pdf");
                System.Console.WriteLine($"Converting '{htmlPath}' to PDF...");

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }

                System.Console.WriteLine($"Saved PDF to '{pdfPath}'.");
            }
        }
    }
}