// Batch convert a set of HTML files to PDF, compressing images to reduce overall file size.

using System;

class Program
{
    static void Main(string[] args)
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
                    options.JpegQuality = 50;
                    options.HorizontalResolution = 72;
                    options.VerticalResolution = 72;
                    options.BackgroundColor = System.Drawing.Color.White;

                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}