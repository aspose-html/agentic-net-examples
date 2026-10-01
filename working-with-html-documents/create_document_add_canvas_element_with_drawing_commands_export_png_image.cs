// Create a document, add a canvas element with drawing commands, and export to PNG image.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputPngPath = "output.png";

            if (!File.Exists(inputHtmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><canvas id='c' width='200' height='200'></canvas><script>var canvas=document.getElementById('c');var ctx=canvas.getContext('2d');ctx.fillStyle='red';ctx.fillRect(10,10,180,180);</script></body></html>";
                File.WriteAllText(inputHtmlPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.UseAntialiasing = false;
            options.HorizontalResolution = 100;
            options.VerticalResolution = 100;
            options.BackgroundColor = System.Drawing.Color.Beige;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPngPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}