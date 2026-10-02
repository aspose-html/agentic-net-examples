// Batch process a directory of HTML files to add alt text and save each modified file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            // Ensure input folder exists and contains at least one sample file
            if (!System.IO.Directory.Exists(inputFolder))
            {
                System.IO.Directory.CreateDirectory(inputFolder);
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><img src=\"image.png\"></body></html>");
            }

            System.IO.Directory.CreateDirectory(outputFolder);

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

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}