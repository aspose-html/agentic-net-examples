// Implement asynchronous batch processing to convert thousands of HTML files to flattened PDFs without blocking the UI thread.

namespace MyApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputPdf";
                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);

                if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                    string sampleContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
                    System.IO.File.WriteAllText(samplePath, sampleContent);
                }

                string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                var tasks = new System.Collections.Generic.List<System.Threading.Tasks.Task>();

                foreach (string htmlPath in htmlFiles)
                {
                    string pdfPath = System.IO.Path.ChangeExtension(System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileName(htmlPath)), ".pdf");
                    tasks.Add(ConvertHtmlToPdfAsync(htmlPath, pdfPath));
                }

                await System.Threading.Tasks.Task.WhenAll(tasks);
                System.Console.WriteLine("Conversion completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static System.Threading.Tasks.Task ConvertHtmlToPdfAsync(string htmlPath, string pdfPath)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
            });
        }
    }
}