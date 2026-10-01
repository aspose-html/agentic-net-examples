// Batch convert a set of HTML files to PDF, compressing images to reduce overall file size.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exists
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Convert each HTML file to JPEG image
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Convert a single HTML file to PDF with custom page size and background color
            string pdfOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            using (Aspose.Html.HTMLDocument docPdf = new Aspose.Html.HTMLDocument(sampleHtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Define page size (8.5 x 11 inches) and zero margins
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11));
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                pdfOptions.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertHTML(docPdf, pdfOptions, pdfOutputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}