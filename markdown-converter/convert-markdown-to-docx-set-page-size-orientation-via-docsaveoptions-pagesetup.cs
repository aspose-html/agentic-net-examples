// Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSetup.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Document\r\n\r\nThis is a **markdown** document converted to DOCX.";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Create DOCX save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define page size (e.g., A4 landscape: width 842, height 595) and margins (left, top, right, bottom)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(842, 595);
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72); // 1 inch margins

            // Create page with size and margin
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);

            // Apply page setup to any page
            options.PageSetup.AnyPage = page;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Perform conversion from HTML to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown successfully converted to DOCX at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}