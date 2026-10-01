// Convert an HTML file to a PNG image using default conversion settings and a file path.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.png";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}