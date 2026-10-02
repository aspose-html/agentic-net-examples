// Batch convert a directory of HTML files to high‑resolution JPGs by iterating over ConvertHTML with ImageRenderingOptions.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputJpg";

                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);

                string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                if (htmlFiles.Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                    System.IO.File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
                    htmlFiles = new string[] { samplePath };
                }

                foreach (string htmlPath in htmlFiles)
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
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