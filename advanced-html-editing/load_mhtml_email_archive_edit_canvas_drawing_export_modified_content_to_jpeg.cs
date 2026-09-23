// Load an MHTML email archive, edit its canvas drawing, and export the modified content to JPEG.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.jpg";

                if (!System.IO.File.Exists(inputPath))
                {
                    string minimalHtml = "<html><body><canvas id='c' width='200' height='100'></canvas></body></html>";
                    System.IO.File.WriteAllText(inputPath, minimalHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                context.FillStyle = "red";
                context.FillRect(10, 10, 180, 80);

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
                document.RenderTo(device);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}