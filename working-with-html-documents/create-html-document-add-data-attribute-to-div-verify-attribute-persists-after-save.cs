// Create an HTML document, add a data‑attribute to a div, and verify attribute persists after save.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            Aspose.Html.HTMLElement div = (Aspose.Html.HTMLElement)doc.CreateElement("div");
            div.SetAttribute("data-test", "12345");
            body.AppendChild(div);

            doc.Save(outputPath);

            Aspose.Html.HTMLDocument loadedDoc = new Aspose.Html.HTMLDocument(outputPath);
            Aspose.Html.Collections.HTMLCollection divs = loadedDoc.GetElementsByTagName("div");
            if (divs.Length > 0)
            {
                Aspose.Html.HTMLElement loadedDiv = (Aspose.Html.HTMLElement)divs[0];
                string attrValue = loadedDiv.GetAttribute("data-test");
                System.Console.WriteLine("Data attribute after reload: " + attrValue);
            }
            else
            {
                System.Console.WriteLine("Div not found after reload.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}