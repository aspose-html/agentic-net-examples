// Load an SVG from a URL and convert it to DOCX with custom DocSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string svgUrl = "https://example.com/sample.svg";
            string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "sample.docx");

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertSVG(svgUrl, options, outputPath);
            System.Console.WriteLine("SVG converted to DOCX successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}