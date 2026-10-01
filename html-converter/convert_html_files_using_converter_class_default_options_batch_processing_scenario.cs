// Use the Converter class to convert HTML files with default options in a batch processing scenario.

class Program
{
    static void Main()
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
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
            System.Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}