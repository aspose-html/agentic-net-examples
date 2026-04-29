// Renumber an ordered list after deleting items to maintain proper numeric ordering.

using System;
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
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            HTMLCollection olCollection = document.GetElementsByTagName("ol");
            foreach (Element olElem in olCollection)
            {
                HTMLOListElement ol = (HTMLOListElement)olElem;
                HTMLCollection liCollection = ol.GetElementsByTagName("li");
                var liList = liCollection.ToList();

                // Example deletion: remove every second list item
                for (int i = 0; i < liList.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        liList[i].ParentNode.RemoveChild(liList[i]);
                    }
                }

                // Renumber remaining items
                HTMLCollection remainingLis = ol.GetElementsByTagName("li");
                int index = 1;
                foreach (Element li in remainingLis)
                {
                    li.SetAttribute("value", index.ToString());
                    index++;
                }
            }

            document.Save(outputPath);
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}