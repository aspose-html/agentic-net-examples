// Generate a consolidated reference list for all URLs used in the document and insert it.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                       "<h1>Example Document</h1>" +
                                       "<p>Visit <a href=\"https://example.com\">Example</a> and see the image below.</p>" +
                                       "<img src=\"https://example.com/image.png\" alt=\"Sample Image\" />" +
                                       "</body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Collect all URLs from <a> href attributes and <img> src attributes
                System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>();

                // Process <a> elements
                HTMLCollection linkElements = document.GetElementsByTagName("a");
                for (int i = 0; i < linkElements.Length; i++)
                {
                    Element linkElement = linkElements[i];
                    string href = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) && !urls.Contains(href))
                    {
                        urls.Add(href);
                    }
                }

                // Process <img> elements
                HTMLCollection imgElements = document.GetElementsByTagName("img");
                for (int i = 0; i < imgElements.Length; i++)
                {
                    Element imgElement = imgElements[i];
                    string src = imgElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src) && !urls.Contains(src))
                    {
                        urls.Add(src);
                    }
                }

                // Create a consolidated reference list (<ul>) and populate it
                HTMLElement ulElement = (HTMLElement)document.CreateElement("ul");
                foreach (string url in urls)
                {
                    HTMLElement liElement = (HTMLElement)document.CreateElement("li");
                    liElement.TextContent = url;
                    ulElement.AppendChild(liElement);
                }

                // Insert the reference list at the end of the body
                document.Body.AppendChild(ulElement);

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Reference list inserted and document saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}