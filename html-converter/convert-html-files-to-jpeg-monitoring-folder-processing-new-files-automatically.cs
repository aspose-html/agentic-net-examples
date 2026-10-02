// Convert HTML files to JPEG by monitoring a folder and processing new files automatically.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output folders
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OutputJpeg");

            // Ensure folders exist
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(sampleHtmlPath))
            {
                System.IO.File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Track processed files
            System.Collections.Generic.HashSet<string> processedFiles = new System.Collections.Generic.HashSet<string>();

            // Poll the folder a fixed number of times
            for (int iteration = 0; iteration < 5; iteration++)
            {
                string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
                foreach (string htmlPath in htmlFiles)
                {
                    if (!processedFiles.Contains(htmlPath))
                    {
                        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                        {
                            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                            string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        }
                        processedFiles.Add(htmlPath);
                    }
                }
                System.Threading.Thread.Sleep(200);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}