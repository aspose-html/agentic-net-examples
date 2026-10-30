// Batch convert all HTML files in a folder to PDF using a foreach loop and Converter.ConvertHTML.

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";
            System.IO.Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(htmlPath), ".pdf");
                    string pdfPath = System.IO.Path.Combine(outputFolder, pdfFileName);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    System.Console.WriteLine("Converted: " + htmlPath + " -> " + pdfPath);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}