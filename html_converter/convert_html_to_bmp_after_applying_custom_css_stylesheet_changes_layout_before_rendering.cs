// Convert HTML to BMP after applying a custom CSS stylesheet that changes layout before rendering.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string outputPath = "output.bmp";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            body.Style.BackgroundColor = "lightgray";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}