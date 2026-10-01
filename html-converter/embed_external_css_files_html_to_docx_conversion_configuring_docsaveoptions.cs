// Embed external CSS files during HTML to DOCX conversion by configuring DocSaveOptions accordingly.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string dataDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data");
                System.IO.Directory.CreateDirectory(dataDir);
                string cssPath = System.IO.Path.Combine(dataDir, "style.css");
                System.IO.File.WriteAllText(cssPath, "body { font-family: Arial; color: blue; }");
                string htmlPath = System.IO.Path.Combine(dataDir, "sample.html");
                string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\" /></head><body><h1>Hello World</h1><p>This is a test.</p></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
                string outputDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Output");
                System.IO.Directory.CreateDirectory(outputDir);
                string outputPath = System.IO.Path.Combine(outputDir, "result.docx");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed. Output: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}