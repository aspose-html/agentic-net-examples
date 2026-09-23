// Extract the text content of all list items within a navigation menu using a CSS selector.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><body><nav><ul><li>Home</li><li>About</li><li>Contact</li></ul></nav></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");
            var elements = document.QuerySelectorAll("nav li");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                System.Console.WriteLine(element.InnerHTML);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}