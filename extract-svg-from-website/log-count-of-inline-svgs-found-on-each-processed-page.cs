// Log the count of inline SVGs found on each processed page.

class Program
{
    static void Main()
    {
        try
        {
            string[] pages = new string[]
            {
                "<html><body><svg></svg><svg></svg></body></html>",
                "<html><body><div>No SVG here</div></body></html>",
                "<html><body><svg></svg></body></html>"
            };

            for (int i = 0; i < pages.Length; i++)
            {
                string htmlContent = pages[i];
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                int count = svgs.Length;
                System.Console.WriteLine($"Page {i + 1}: Found {count} inline SVG(s).");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}