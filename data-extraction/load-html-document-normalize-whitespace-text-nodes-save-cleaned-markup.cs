// Load an HTML document, normalize whitespace in text nodes, and save the cleaned markup.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>   This   is   a   test. </p><div>   Another   <span>   example   </span>   </div></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");
                foreach (Aspose.Html.HTMLElement element in allElements)
                {
                    Aspose.Html.Dom.Node child = element.FirstChild;
                    while (child != null)
                    {
                        if (child is Aspose.Html.Dom.Text textNode)
                        {
                            string normalized = Regex.Replace(textNode.Data, @"\s+", " ").Trim();
                            textNode.Data = normalized;
                        }
                        child = child.NextSibling;
                    }
                }

                string outputPath = "cleaned.html";
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}