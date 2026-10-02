// Create a text node with Unicode characters, append to a div, and save the document as UTF-8 HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            Aspose.Html.Dom.Element div = document.CreateElement("div");

            Aspose.Html.Dom.Text text = document.CreateTextNode("Hello, 世界 🌍!");

            div.AppendChild(text);
            document.Body.AppendChild(div);

            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}