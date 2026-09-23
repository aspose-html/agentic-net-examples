// Traverse the DOM to find the first child element of the body and output its tag name.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div>Content</div><p>Paragraph</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");
            Aspose.Html.Dom.Element body = document.Body;
            Aspose.Html.Dom.Element first = body.FirstElementChild;
            string tagName = first.TagName;
            Console.WriteLine(tagName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}