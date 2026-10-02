// Convert a batch of HTML files to JPEG images with varying quality settings based on file size.

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OutputJpeg");
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            string[] existingFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string smallPath = System.IO.Path.Combine(inputFolder, "small.html");
                string largePath = System.IO.Path.Combine(inputFolder, "large.html");
                System.IO.File.WriteAllText(smallPath, "<html><body><h1>Small File</h1></body></html>");
                System.IO.File.WriteAllText(largePath, "<html><body>" + new string('A', 5000) + "</body></html>");
            }

            // Process each HTML file
            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                long fileSize = new System.IO.FileInfo(htmlPath).Length;

                // Determine resolution based on file size
                int horizontalResolution = 96;
                int verticalResolution = 96;
                if (fileSize > 2000) // larger files get higher resolution
                {
                    horizontalResolution = 150;
                    verticalResolution = 150;
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = horizontalResolution;
                    options.VerticalResolution = verticalResolution;

                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}