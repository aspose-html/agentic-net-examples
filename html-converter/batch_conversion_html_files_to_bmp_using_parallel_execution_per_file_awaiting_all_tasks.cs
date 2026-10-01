// Perform batch conversion of HTML files to BMP using Task.Run for each file and awaiting all tasks.

namespace Example
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputBmp";
                System.IO.Directory.CreateDirectory(outputFolder);
                string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                var tasks = new System.Collections.Generic.List<System.Threading.Tasks.Task>();
                foreach (string htmlPath in htmlFiles)
                {
                    tasks.Add(System.Threading.Tasks.Task.Run(() =>
                    {
                        using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                        {
                            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                            string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".bmp");
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        }
                    }));
                }
                await System.Threading.Tasks.Task.WhenAll(tasks);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}