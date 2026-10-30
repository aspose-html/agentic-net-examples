// Select all anchor elements with href ending in ".pdf" using CSS selector and log URLs.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href='doc1.pdf'>Document 1</a>" +
                                 "<a href='doc2.doc'>Document 2</a>" +
                                 "<a href='folder/doc3.pdf'>Document 3</a>" +
                                 "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList pdfLinks = document.QuerySelectorAll("a[href$='.pdf']");

            foreach (Aspose.Html.Dom.Node node in pdfLinks)
            {
                Aspose.Html.HTMLElement linkElement = node as Aspose.Html.HTMLElement;
                if (linkElement != null)
                {
                    string href = linkElement.GetAttribute("href");
                    System.Console.WriteLine(href);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}