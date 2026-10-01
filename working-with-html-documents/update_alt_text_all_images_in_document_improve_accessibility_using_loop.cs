// Update alt text of all images in the document to improve accessibility using a loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><img src=\"image1.png\" /><img src=\"photo.jpg\" alt=\"\" /></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string src = img.GetAttribute("src");
                        string autoAlt = "Image";
                        if (!string.IsNullOrWhiteSpace(src))
                        {
                            string fileName = Path.GetFileNameWithoutExtension(src);
                            if (!string.IsNullOrWhiteSpace(fileName))
                            {
                                autoAlt = fileName;
                            }
                        }
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            document.Save(outputPath);
            Console.WriteLine("Alt attributes updated and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}