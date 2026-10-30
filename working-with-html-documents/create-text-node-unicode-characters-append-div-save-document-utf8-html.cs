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
            Aspose.Html.Dom.Text text = document.CreateTextNode("Unicode: Привет, 你好, 🌍");

            div.AppendChild(text);
            document.Body.AppendChild(div);

            document.Save(outputPath);

            Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}