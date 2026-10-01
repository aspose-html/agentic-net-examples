// Insert footnote definitions at the end of the document for each referenced footnote marker.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with footnote markers
            string htmlContent = "<html><head><title>Sample</title></head><body><p>Text with footnote <a href=\"#fn1\" id=\"ref1\">[1]</a> and another <a href=\"#fn2\" id=\"ref2\">[2]</a>.</p></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all anchor elements
            Aspose.Html.Collections.HTMLCollection anchors = document.GetElementsByTagName("a");

            // Ensure an ordered list for footnotes exists at the end of the body
            Aspose.Html.Collections.HTMLCollection orderedLists = document.GetElementsByTagName("ol");
            Aspose.Html.Dom.Element footnoteList;
            if (orderedLists.Length > 0)
            {
                footnoteList = orderedLists[0];
            }
            else
            {
                footnoteList = document.CreateElement("ol");
                document.Body.AppendChild(footnoteList);
            }

            // Iterate over anchors to find footnote references
            for (int i = 0; i < anchors.Length; i++)
            {
                Aspose.Html.Dom.Element anchor = anchors[i];
                string href = anchor.GetAttribute("href");
                if (!string.IsNullOrEmpty(href) && href.StartsWith("#fn"))
                {
                    string footnoteId = href.Substring(1); // remove '#'

                    // Create footnote definition element
                    Aspose.Html.Dom.Element li = document.CreateElement("li");
                    li.SetAttribute("id", footnoteId);
                    li.TextContent = $"Footnote definition for {footnoteId}";

                    // Append definition to the ordered list
                    footnoteList.AppendChild(li);
                }
            }

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}