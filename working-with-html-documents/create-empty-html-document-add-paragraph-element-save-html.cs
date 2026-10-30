// Create an empty HTML document, add a paragraph element, and save it as HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)doc.CreateElement("p");
            Aspose.Html.Dom.Text txt = doc.CreateTextNode("This is a paragraph.");
            p.AppendChild(txt);
            doc.Body.AppendChild(p);
            doc.Save(outputPath);
            Console.WriteLine("HTML document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}