// Convert HTML to DOCX while preserving table structures by using default DocRenderingOptions.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.docx";

            string htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body><table border='1'><tr><th>Header1</th><th>Header2</th></tr><tr><td>Cell1</td><td>Cell2</td></tr></table></body></html>";
            System.IO.File.WriteAllText(sourcePath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

            document.RenderTo(device);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}