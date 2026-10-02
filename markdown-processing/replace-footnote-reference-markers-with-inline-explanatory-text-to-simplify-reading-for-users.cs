// Replace footnote reference markers with inline explanatory text to simplify reading for users.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with footnote reference and definition
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<p>This is a sentence with a footnote reference<sup id='fnref1'><a href='#fn1'>1</a></sup>.</p>
<p>Another sentence with a second footnote<sup id='fnref2'><a href='#fn2'>2</a></sup>.</p>

<hr/>
<ol>
<li id='fn1'>First footnote explanation.</li>
<li id='fn2'>Second footnote explanation.</li>
</ol>
</body>
</html>";

            // Load HTML document from string (inline content)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all footnote reference links (href starts with '#fn')
            Aspose.Html.Collections.NodeList anchors = document.QuerySelectorAll("a[href^='#fn']");

            foreach (Aspose.Html.Dom.Element anchor in anchors)
            {
                string href = anchor.GetAttribute("href");
                if (string.IsNullOrEmpty(href) || !href.StartsWith("#"))
                    continue;

                string footnoteId = href.Substring(1); // remove leading '#'
                Aspose.Html.Dom.Element footnoteElement = document.GetElementById(footnoteId) as Aspose.Html.Dom.Element;
                if (footnoteElement == null)
                    continue;

                string footnoteText = footnoteElement.TextContent.Trim();

                // Create inline explanatory text node
                Aspose.Html.Dom.Text textNode = document.CreateTextNode($" ({footnoteText})");

                // Replace the anchor element with the text node
                Aspose.Html.Dom.Node parent = anchor.ParentNode;
                parent.ReplaceChild(textNode, anchor);
            }

            // Save the modified HTML to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine("Footnote references have been replaced with inline text.");
            Console.WriteLine("Modified HTML saved at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}