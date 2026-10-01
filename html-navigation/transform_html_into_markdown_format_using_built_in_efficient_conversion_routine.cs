// Transform the HTML into Markdown format using a built‑in efficient conversion routine.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string savePath = "output.md";

            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1><p>This is a sample HTML.</p></body></html>");

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            System.Console.WriteLine("Conversion completed. Markdown saved at " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}