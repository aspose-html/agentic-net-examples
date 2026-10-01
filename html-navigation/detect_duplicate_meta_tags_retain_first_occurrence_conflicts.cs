// Detect duplicate meta tags and retain only the first occurrence to avoid conflicts.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<meta name=\"description\" content=\"first\">" +
                                 "<meta name=\"description\" content=\"duplicate\">" +
                                 "<meta name=\"keywords\" content=\"sample\">" +
                                 "<meta name=\"keywords\" content=\"duplicate2\">" +
                                 "</head><body><p>Hello</p></body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Get all meta elements
            Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");

            // Track seen meta name attributes
            HashSet<string> seenNames = new HashSet<string>();

            // Iterate backwards to safely remove duplicates
            for (int i = metaElements.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element meta = (Aspose.Html.Dom.Element)metaElements[i];
                string name = meta.GetAttribute("name");
                if (string.IsNullOrEmpty(name))
                    continue;

                if (!seenNames.Add(name))
                {
                    // Duplicate found, remove from DOM
                    Aspose.Html.Dom.Node parent = meta.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(meta);
                    }
                }
            }

            // Save the cleaned HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}