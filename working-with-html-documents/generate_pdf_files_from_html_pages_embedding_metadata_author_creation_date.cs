// Generate PDF files from HTML pages, embedding metadata such as author and creation date.

using System;

namespace HtmlToPdfWithMetadata
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                string baseUrl = "http://example.com/";
                string outputPath = "output.pdf";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUrl);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                options.DocumentInfo.Title = "Sample PDF";
                options.DocumentInfo.Author = "John Doe";
                options.DocumentInfo.Subject = "Demo PDF Generation";
                options.DocumentInfo.Keywords = "Aspose,HTML,PDF,Metadata";
                options.DocumentInfo.CreationDate = DateTime.Now;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("PDF generated successfully at " + outputPath);
                document.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}