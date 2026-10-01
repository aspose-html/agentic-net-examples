// Perform parallel conversion of multiple HTML files to PNG using Parallel.ForEach to improve processing speed.

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPng";
            System.IO.Directory.CreateDirectory(outputFolder);
            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            System.Threading.Tasks.Parallel.ForEach(htmlFiles, htmlPath =>
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            });
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}