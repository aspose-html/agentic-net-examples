// Update existing base tag href attribute to a new domain for site migration.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "updated.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><base href=\"https://old-domain.com/\"/></head><body><p>Hello</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection baseElements = document.GetElementsByTagName("base");
                if (baseElements.Length > 0)
                {
                    Element baseElement = (Element)baseElements[0];
                    string newDomain = "https://new-domain.com/";
                    baseElement.SetAttribute("href", newDomain);
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Base href updated and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}