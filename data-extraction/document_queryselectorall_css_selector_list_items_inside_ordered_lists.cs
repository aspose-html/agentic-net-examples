// Use Document.QuerySelectorAll with a CSS selector to obtain all list items inside ordered lists.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><ol><li>Item 1</li><li>Item 2</li></ol><ol><li>Item A</li></ol></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");
            var elements = document.QuerySelectorAll("ol li");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)elements[i];
                System.Console.WriteLine(element.InnerHTML);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}