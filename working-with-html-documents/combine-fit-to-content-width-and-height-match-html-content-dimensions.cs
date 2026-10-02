// Combine PageLayoutOptions.FitToContentWidth and FitToContentHeight to match both width and height to HTML content.

class Program
{
    static void Main()
    {
        try
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string htmlPath = System.IO.Path.Combine(currentDir, "sample.html");
            string outputPath = System.IO.Path.Combine(currentDir, "output.png");

            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample.</p></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions opt = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                opt.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth | Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(opt, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            System.Console.WriteLine("Image saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}