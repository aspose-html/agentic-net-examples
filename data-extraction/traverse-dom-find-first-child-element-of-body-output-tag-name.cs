// Traverse the DOM to find the first child element of the body and output its tag name.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><div>First</div><p>Second</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element body = document.Body;
            Aspose.Html.Dom.Element firstElement = body.FirstElementChild;
            string tagName = firstElement.TagName;
            Console.WriteLine(tagName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}