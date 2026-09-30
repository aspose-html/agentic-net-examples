// Convert HTML to XPS using XpsRenderingOptions to define custom top and bottom margins.

public class Program
{
    public static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(0, 1, 0, 1));

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            System.Console.WriteLine("Conversion completed successfully. XPS saved to: " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}