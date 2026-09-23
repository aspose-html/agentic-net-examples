// Create a reusable method that accepts a page URL and returns a list of extracted inline SVG strings.

public class Program
{
    public static void Main()
    {
        try
        {
            string url = "https://example.com";
            var svgs = ExtractInlineSvgs(url);
            System.Console.WriteLine($"Extracted {svgs.Count} SVG(s) from {url}");
            for (int i = 0; i < svgs.Count; i++)
            {
                System.Console.WriteLine($"SVG {i}:");
                System.Console.WriteLine(svgs[i]);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static System.Collections.Generic.List<string> ExtractInlineSvgs(string pageUrl)
    {
        var svgList = new System.Collections.Generic.List<string>();
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl);
        Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
        for (int i = 0; i < svgs.Length; i++)
        {
            Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
            string markup = svgElement.OuterHTML;
            svgList.Add(markup);
        }
        return svgList;
    }
}