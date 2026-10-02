// Remove duplicate ID attributes by appending numeric suffixes to ensure uniqueness throughout the document.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div id='item'>First</div><p id='item'>Second</p><span id='unique'>Third</span></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");
            var seenIds = new HashSet<string>();
            for (int i = 0; i < allElements.Length; i++)
            {
                var element = (Aspose.Html.HTMLElement)allElements[i];
                string id = element.GetAttribute("id");
                if (string.IsNullOrEmpty(id))
                    continue;
                if (!seenIds.Add(id))
                {
                    int suffix = 1;
                    string newId;
                    do
                    {
                        newId = id + "_" + suffix;
                        suffix++;
                    } while (!seenIds.Add(newId));
                    element.SetAttribute("id", newId);
                }
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Processed document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}