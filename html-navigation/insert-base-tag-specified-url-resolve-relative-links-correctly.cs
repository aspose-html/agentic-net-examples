// Insert a base tag with a specified URL to resolve relative links correctly.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src=\"images/pic.png\" /></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Dom.Element baseElement = document.CreateElement("base");
                baseElement.SetAttribute("href", "https://example.com/");

                Aspose.Html.Collections.HTMLCollection heads = document.GetElementsByTagName("head");
                if (heads.Length > 0)
                {
                    Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)heads[0];
                    head.AppendChild(baseElement);
                }

                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}