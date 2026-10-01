// Move a script element from the head to the end of the body to improve page loading.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><script src=\"script.js\"></script></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get head and body elements
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)Enumerable.First(document.GetElementsByTagName("head"));
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)Enumerable.First(document.GetElementsByTagName("body"));

            // Get all script elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            // Move script elements from head to the end of body
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                if (scriptElement.ParentNode == head)
                {
                    head.RemoveChild(scriptElement);
                    body.AppendChild(scriptElement);
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}