// Define custom background color in ImageSaveOptions before converting HTML to PNG to replace transparent areas.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.png";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.UseAntialiasing = false;
            options.HorizontalResolution = 100;
            options.VerticalResolution = 100;
            options.BackgroundColor = System.Drawing.Color.LightBlue;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}