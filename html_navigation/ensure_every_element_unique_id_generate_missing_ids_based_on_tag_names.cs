// Ensure every element has a unique ID by generating missing IDs based on tag names.

using System;
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
            string htmlContent = "<html><body><div></div><p id='p1'></p><span></span></body></html>";
            var document = new HTMLDocument(htmlContent, "");
            var allElements = document.GetElementsByTagName("*");
            var usedIds = new HashSet<string>();
            int counter = 1;
            for (int i = 0; i < allElements.Length; i++)
            {
                var element = (Element)allElements[i];
                string id = element.Id;
                if (!string.IsNullOrEmpty(id))
                {
                    usedIds.Add(id);
                }
                else
                {
                    string baseId = element.TagName.ToLower();
                    string newId;
                    do
                    {
                        newId = $"{baseId}_{counter++}";
                    } while (usedIds.Contains(newId));
                    element.Id = newId;
                    usedIds.Add(newId);
                }
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}