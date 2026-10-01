// Replace footnote reference markers with inline explanatory text to simplify reading for users.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Sample text<sup><a href=\"#fn1\">1</a></sup>.</p><ol class=\"footnotes\"><li id=\"fn1\">This is the footnote text.</li></ol></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "");
            var references = document.QuerySelectorAll("a[href^='#fn']");
            for (int i = 0; i < references.Length; i++)
            {
                var refElement = references[i] as Aspose.Html.HTMLElement;
                if (refElement == null) continue;
                string href = refElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href) || !href.StartsWith("#")) continue;
                string targetId = href.Substring(1);
                var footnote = document.GetElementById(targetId) as Aspose.Html.HTMLElement;
                if (footnote == null) continue;
                string footnoteText = footnote.TextContent;
                var textNode = document.CreateTextNode(" (" + footnoteText + ")");
                refElement.ParentNode.ReplaceChild(textNode, refElement);
            }
            var footnoteList = document.QuerySelector("ol.footnotes") as Aspose.Html.HTMLElement;
            if (footnoteList != null)
            {
                footnoteList.ParentNode.RemoveChild(footnoteList);
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}