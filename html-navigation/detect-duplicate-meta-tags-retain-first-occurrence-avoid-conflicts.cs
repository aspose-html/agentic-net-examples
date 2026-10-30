// Detect duplicate meta tags and retain only the first occurrence to avoid conflicts.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"First\"><meta name=\"description\" content=\"Duplicate\"><meta name=\"keywords\" content=\"sample\"><meta name=\"keywords\" content=\"duplicate\"></head><body><p>Hello</p></body></html>";
            string baseUri = "about:blank";

            using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
            {
                HTMLCollection metaElements = document.GetElementsByTagName("meta");
                HashSet<string> seenNames = new HashSet<string>();

                for (int i = metaElements.Length - 1; i >= 0; i--)
                {
                    HTMLElement meta = (HTMLElement)metaElements[i];
                    string nameAttr = meta.GetAttribute("name");
                    if (String.IsNullOrEmpty(nameAttr))
                    {
                        nameAttr = meta.GetAttribute("http-equiv");
                    }

                    if (String.IsNullOrEmpty(nameAttr))
                    {
                        continue;
                    }

                    if (!seenNames.Add(nameAttr))
                    {
                        Node parent = meta.ParentNode;
                        if (parent != null)
                        {
                            parent.RemoveChild(meta);
                        }
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Processed HTML saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}