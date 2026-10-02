// Insert a line break within a long heading text to improve readability on narrow screens.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");

            Aspose.Html.Dom.Text txtPart1 = doc.CreateTextNode("This is a very long heading that");
            h1.AppendChild(txtPart1);

            Aspose.Html.HTMLElement br = (Aspose.Html.HTMLElement)doc.CreateElement("br");
            h1.AppendChild(br);

            Aspose.Html.Dom.Text txtPart2 = doc.CreateTextNode("needs to be broken into two lines.");
            h1.AppendChild(txtPart2);

            body.AppendChild(h1);

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}