// Convert HTML to PNG after injecting custom JavaScript that modifies the DOM for dynamic content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Test</title></head><body><div id='placeholder'>Original</div></body></html>";
            Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.HTMLScriptElement script = (Aspose.Html.HTMLScriptElement)htmlDocument.CreateElement("script");
            script.Text = "document.getElementById('placeholder').innerHTML = 'Dynamic content injected by JavaScript';";
            htmlDocument.Body.AppendChild(script);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlDocument, options, outputPath);
            Console.WriteLine("Conversion completed. PNG saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}