// Set DOCX page orientation to landscape using DocSaveOptions when converting HTML to DOCX.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello World</h1></body></html>";
            // Load HTML from string (base URI is required)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Create DOCX save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define landscape page size (A4 landscape)
            Aspose.Html.Drawing.Length width = Aspose.Html.Drawing.Length.FromInches(11.69f);
            Aspose.Html.Drawing.Length height = Aspose.Html.Drawing.Length.FromInches(8.27f);
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(width, height);
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);

            // Apply page setup
            options.PageSetup.AnyPage = page;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Convert HTML to DOCX with landscape orientation
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}