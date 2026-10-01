// Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions.

public class Program
{
    public static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            // Create a sample HTML file with a canvas element if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><canvas id='myCanvas' width='200' height='100' style='border:1px solid #000000;'></canvas><script>var c=document.getElementById('myCanvas');var ctx=c.getContext('2d');ctx.fillStyle='red';ctx.fillRect(10,10,150,75);</script></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}