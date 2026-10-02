// Add a custom data‑attribute to all heading elements for JavaScript interaction later.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument();
            var body = document.Body;

            var h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.SetAttribute("data-custom", "heading1");
            h1.AppendChild(document.CreateTextNode("Heading 1"));
            body.AppendChild(h1);

            var h2 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
            h2.SetAttribute("data-custom", "heading2");
            h2.AppendChild(document.CreateTextNode("Heading 2"));
            body.AppendChild(h2);

            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}