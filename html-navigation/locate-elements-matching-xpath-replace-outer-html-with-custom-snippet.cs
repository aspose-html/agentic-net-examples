// Locate elements matching an XPath expression and replace their outer HTML with a custom snippet.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p class='target'>Hello</p><div>Other</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            string xpath = "//*[contains(@class,'target')]";
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(xpath, document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                var element = node as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    element.OuterHTML = "<span class='replaced'>Replaced Content</span>";
                }
            }

            document.Save("output.html");
            Console.WriteLine("Processing completed. Output saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}