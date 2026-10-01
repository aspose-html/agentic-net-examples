// Convert a batch of HTML files located in a directory to PNG images using a foreach loop.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputImages";
                System.IO.Directory.CreateDirectory(outputFolder);
                foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                        string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}