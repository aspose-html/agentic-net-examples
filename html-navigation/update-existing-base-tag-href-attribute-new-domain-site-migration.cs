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
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><base href=\"http://old-domain.com/\"/></head><body><p>Hello</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                HTMLCollection baseElements = document.GetElementsByTagName("base");
                if (baseElements.Length > 0)
                {
                    Aspose.Html.Dom.Element baseElement = (Aspose.Html.Dom.Element)baseElements[0];
                    baseElement.SetAttribute("href", "https://new-domain.com/");
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Base tag href updated and document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}