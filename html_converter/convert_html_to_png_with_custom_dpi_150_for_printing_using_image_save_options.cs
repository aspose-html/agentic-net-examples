// Convert HTML to PNG with custom DPI of 150 for printing purposes by configuring ImageSaveOptions accordingly.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            HTMLDocument document = new HTMLDocument("input.html");
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;
            Converter.ConvertHTML(document, options, "output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}