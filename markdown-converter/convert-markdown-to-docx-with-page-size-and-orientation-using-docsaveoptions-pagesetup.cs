// Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSetup.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Document\n\nThis is a sample markdown converted to DOCX.";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Prepare DOCX save options with custom page size (A4 portrait)
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Drawing.Length width = Aspose.Html.Drawing.Length.FromInches(8.27f);
            Aspose.Html.Drawing.Length height = Aspose.Html.Drawing.Length.FromInches(11.69f);
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(width, height);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size);
            options.PageSetup.AnyPage = page;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Perform conversion and save
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}