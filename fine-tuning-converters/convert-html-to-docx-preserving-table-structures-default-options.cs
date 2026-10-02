// Convert HTML to DOCX while preserving table structures by using default DocRenderingOptions.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.docx";

            if (!System.IO.File.Exists(sourcePath))
            {
                string htmlContent = "<html><body><table border='1'><tr><td>Cell 1</td><td>Cell 2</td></tr></table></body></html>";
                System.IO.File.WriteAllText(sourcePath, htmlContent);
            }

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