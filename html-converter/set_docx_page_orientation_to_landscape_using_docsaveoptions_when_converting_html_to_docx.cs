// Set DOCX page orientation to landscape using DocSaveOptions when converting HTML to DOCX.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Drawing.Length width = Aspose.Html.Drawing.Length.FromInches(11.69f);
            Aspose.Html.Drawing.Length height = Aspose.Html.Drawing.Length.FromInches(8.27f);
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(width, height);
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            string outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}