// Convert relative URLs in anchor tags to absolute URLs using the document’s base URL.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseUri = "https://example.com/";
            string htmlContent = "<html><head><base href='https://example.com/'></head><body><a href='page1.html'>Link1</a><a href='/abs/page2.html'>Link2</a><a href='https://other.com/page3.html'>Link3</a></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                linkElement.SetAttribute("href", resolvedUrl.ToString());
            }

            string resultHtml = document.DocumentElement.OuterHTML;
            System.Console.WriteLine(resultHtml);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}