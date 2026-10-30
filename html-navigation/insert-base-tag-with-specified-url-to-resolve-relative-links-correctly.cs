// Insert a base tag with a specified URL to resolve relative links correctly.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string baseUrl = "https://example.com/";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src=\"images/pic.png\" /></body></html>");
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Create <base> element with the specified href
                Element baseElement = (Element)document.CreateElement("base");
                baseElement.SetAttribute("href", baseUrl);

                // Insert the <base> element into <head>
                HTMLCollection heads = document.GetElementsByTagName("head");
                if (heads.Length > 0)
                {
                    Element head = (Element)heads[0];
                    // Insert as the first child of <head>
                    head.InsertBefore(baseElement, head.FirstChild);
                }
                else
                {
                    // If <head> does not exist, create it and prepend to <html>
                    Element head = (Element)document.CreateElement("head");
                    head.AppendChild(baseElement);
                    HTMLCollection htmls = document.GetElementsByTagName("html");
                    if (htmls.Length > 0)
                    {
                        Element html = (Element)htmls[0];
                        html.InsertBefore(head, html.FirstChild);
                    }
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Base tag inserted and document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}