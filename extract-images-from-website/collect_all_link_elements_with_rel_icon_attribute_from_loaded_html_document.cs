// Collect all <link> elements with rel='icon' attribute from the loaded HTML document.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><link rel='icon' href='favicon.ico'><link rel='icon' href='icon2.png'><link rel='stylesheet' href='style.css'></head><body></body></html>";
            string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(filePath, htmlContent);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("link");
            for (int i = 0; i < links.Length; i++)
            {
                Aspose.Html.Dom.Element link = links[i];
                string rel = link.GetAttribute("rel");
                if (!string.IsNullOrEmpty(rel) && rel.Equals("icon", System.StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    System.Console.WriteLine($"Icon link: href='{href}'");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}