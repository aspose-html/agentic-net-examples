// Insert footnote definitions at the end of the document for each referenced footnote marker.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>Sample text<sup class='footnote-ref' id='ref1'>1</sup></p><ol class='footnotes'><li id='fn1'>Footnote 1 definition.</li></ol></body></html>";
            string baseUri = "about:blank";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri))
            {
                Aspose.Html.Collections.HTMLCollection footnoteLists = document.GetElementsByTagName("ol");
                if (footnoteLists.Length >= 1)
                {
                    Aspose.Html.Dom.Element footnoteList = footnoteLists[0];
                    footnoteList.ParentNode.RemoveChild(footnoteList);
                    document.Body.AppendChild(footnoteList);
                }

                string outputPath = "output.html";
                document.Save(outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}