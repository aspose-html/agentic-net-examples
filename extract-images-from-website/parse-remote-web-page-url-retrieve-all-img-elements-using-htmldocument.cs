// Parse a remote web page URL and retrieve all <img> elements using HtmlDocument.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    System.Console.WriteLine(src);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}