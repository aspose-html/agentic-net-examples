// Convert an HTML file to an XPS document by calling Converter.ConvertHTML with new XpsSaveOptions.

public class Program
{
    public static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}