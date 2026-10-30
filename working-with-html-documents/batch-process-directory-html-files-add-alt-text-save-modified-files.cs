// Batch process a directory of HTML files to add alt text and save each modified file.

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<html><body><img src=\"image.png\"></body></html>";
                System.IO.File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                    foreach (Aspose.Html.Dom.Element node in images)
                    {
                        Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                        if (img != null)
                        {
                            string alt = img.GetAttribute("alt");
                            if (string.IsNullOrWhiteSpace(alt))
                            {
                                string autoAlt = "Image";
                                img.SetAttribute("alt", autoAlt);
                            }
                        }
                    }

                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileName(htmlPath));
                    document.Save(outputPath);
                }
            }

            System.Console.WriteLine("Processing completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}