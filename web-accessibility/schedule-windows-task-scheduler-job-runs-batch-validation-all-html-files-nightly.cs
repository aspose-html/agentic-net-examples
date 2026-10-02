// Schedule a Windows Task Scheduler job that runs batch validation on all HTML files nightly.

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
                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);
                foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}