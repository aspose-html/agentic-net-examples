// Batch convert HTML files to PDF, naming each output file with the original filename plus a suffix.

namespace MyApp
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

                string[] existingFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                if (existingFiles.Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                    string sampleContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(samplePath, sampleContent);
                }

                foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        string outputPath = System.IO.Path.Combine(outputFolder,
                            System.IO.Path.GetFileNameWithoutExtension(htmlPath) + "_converted.pdf");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }

                System.Console.WriteLine("Batch conversion completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}