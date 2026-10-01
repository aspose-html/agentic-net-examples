// Implement parallel HTML to GIF conversion using Parallel.ForEach and Converter.ConvertHTML for improved performance.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputGif";

                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);

                // Create a sample HTML file if the input folder is empty
                string[] existingFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                if (existingFiles.Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                    System.IO.File.WriteAllText(samplePath, "<html><body><h1>Hello World</h1></body></html>");
                }

                var htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");

                System.Threading.Tasks.Parallel.ForEach(htmlFiles, htmlPath =>
                {
                    try
                    {
                        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                        {
                            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                            string outputPath = System.IO.Path.Combine(outputFolder,
                                System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".gif");
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine($"Error processing '{htmlPath}': {ex.Message}");
                    }
                });

                System.Console.WriteLine("Conversion completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Fatal error: {ex.Message}");
            }
        }
    }
}