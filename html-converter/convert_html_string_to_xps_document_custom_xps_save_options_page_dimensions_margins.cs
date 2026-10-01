// Convert an HTML string to an XPS document using custom XpsSaveOptions that specify page dimensions and margins.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello, XPS!</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.BackgroundColor = System.Drawing.Color.White;
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.3f),
                    Aspose.Html.Drawing.Length.FromInches(5.8f));
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                options.PageSetup.AnyPage = page;
                string outputPath = "output.xps";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}