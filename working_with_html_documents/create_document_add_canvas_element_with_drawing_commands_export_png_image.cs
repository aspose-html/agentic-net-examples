// Create a document, add a canvas element with drawing commands, and export to PNG image.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><canvas id='myCanvas' width='200' height='200'></canvas><script>var c=document.getElementById('myCanvas');var ctx=c.getContext('2d');ctx.fillStyle='red';ctx.fillRect(10,10,100,100);</script></body></html>";
            string htmlPath = Path.Combine(Environment.CurrentDirectory, "canvas.html");
            File.WriteAllText(htmlPath, htmlContent);

            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageSaveOptions options = new ImageSaveOptions();
            options.UseAntialiasing = false;
            options.HorizontalResolution = 100;
            options.VerticalResolution = 100;
            options.BackgroundColor = System.Drawing.Color.Beige;

            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.png");
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}