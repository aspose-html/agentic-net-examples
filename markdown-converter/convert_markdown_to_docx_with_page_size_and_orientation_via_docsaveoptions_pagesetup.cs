// Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSetup.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Document\r\n\r\nThis is a test paragraph in the markdown document.";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Set up DOCX save options with custom page size and margins
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define page size (width, height) in points (e.g., A4 size: 595 x 842 points)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);

            // Define margins (left, top, right, bottom) in points (1 inch = 72 points)
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);

            // Create page setup
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Convert HTMLDocument to DOCX with the specified options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been successfully converted to DOCX at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}