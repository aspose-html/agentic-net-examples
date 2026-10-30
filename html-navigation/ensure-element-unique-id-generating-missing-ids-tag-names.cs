// Ensure every element has a unique ID by generating missing IDs based on tag names.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div><p>Hello</p></div><span></span></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("*");
                Dictionary<string, int> tagCounters = new Dictionary<string, int>();
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = elements[i] as Aspose.Html.Dom.Element;
                    if (element == null)
                        continue;

                    string id = element.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                    {
                        string tag = element.TagName.ToLower();
                        int count;
                        if (!tagCounters.TryGetValue(tag, out count))
                        {
                            count = 0;
                        }
                        count++;
                        tagCounters[tag] = count;
                        string newId = tag + count;
                        element.SetAttribute("id", newId);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Modified HTML saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}