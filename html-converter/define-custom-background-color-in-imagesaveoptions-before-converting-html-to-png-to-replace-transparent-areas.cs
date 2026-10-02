// Define custom background color in ImageSaveOptions before converting HTML to PNG to replace transparent areas.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body style=\"background:transparent;\"><h1>Hello World</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.White;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}