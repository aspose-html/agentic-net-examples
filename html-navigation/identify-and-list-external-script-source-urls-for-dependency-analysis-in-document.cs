// Identify and list all external script source URLs for dependency analysis in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><script src=\"https://example.com/lib.js\"></script></head><body></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");

            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}