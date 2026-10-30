// Remove all deprecated <center> tags and replace them with CSS text‑align styling.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><center>Centered Text</center><p>Paragraph</p><center><b>Bold Center</b></center></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection centers = document.GetElementsByTagName("center");
            for (int i = 0; i < centers.Length; i++)
            {
                Aspose.Html.Dom.Element center = (Aspose.Html.Dom.Element)centers[i];
                Aspose.Html.Dom.Element div = document.CreateElement("div");
                div.SetAttribute("style", "text-align:center;");
                while (center.FirstChild != null)
                {
                    Aspose.Html.Dom.Node child = center.FirstChild;
                    center.RemoveChild(child);
                    div.AppendChild(child);
                }
                Aspose.Html.Dom.Node parent = center.ParentNode;
                parent.ReplaceChild(div, center);
            }
            document.Save("output.html");
            System.Console.WriteLine("Processing completed. Output saved to output.html");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}