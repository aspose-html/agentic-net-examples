// Create an empty HTML document, add a paragraph element, and save it as HTML.

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;
            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)doc.CreateElement("p");
            Aspose.Html.Dom.Text txtP = doc.CreateTextNode("This is a paragraph.");
            p.AppendChild(txtP);
            body.AppendChild(p);
            doc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}