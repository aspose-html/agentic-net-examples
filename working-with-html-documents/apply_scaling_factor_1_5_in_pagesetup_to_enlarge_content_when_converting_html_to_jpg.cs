// Apply scaling factor of 1.5 in PageSetup to enlarge content when converting HTML to JPG.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.jpg";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
                }

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                var document = new Aspose.Html.HTMLDocument(htmlPath);

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}