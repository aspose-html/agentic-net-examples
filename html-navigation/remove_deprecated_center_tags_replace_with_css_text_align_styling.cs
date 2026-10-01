// Remove all deprecated <center> tags and replace them with CSS text‑align styling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><center><p>Hello</p></center><center>World</center></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Collections.HTMLCollection centers = document.GetElementsByTagName("center");

            for (int i = centers.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element center = (Aspose.Html.Dom.Element)centers[i];
                Aspose.Html.Dom.Element div = document.CreateElement("div");
                div.SetAttribute("style", "text-align:center;");

                while (center.HasChildNodes())
                {
                    var child = center.FirstChild;
                    center.RemoveChild(child);
                    div.AppendChild(child);
                }

                Aspose.Html.Dom.Element parent = (Aspose.Html.Dom.Element)center.ParentNode;
                parent.ReplaceChild(div, center);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}