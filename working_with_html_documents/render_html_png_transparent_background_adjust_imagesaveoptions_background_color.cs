// Render HTML to PNG with transparent background by adjusting ImageSaveOptions background color.

using System;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.png";

            ImageSaveOptions options = new ImageSaveOptions();
            options.BackgroundColor = Color.Transparent;

            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}