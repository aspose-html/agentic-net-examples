// Add a bullet list generated from an array of strings at a designated location in the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string[] items = new string[] { "First item", "Second item", "Third item" };
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "output.html");

            HTMLDocument document = new HTMLDocument();
            HTMLElement body = document.Body;

            HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
            Text headingText = document.CreateTextNode("Bullet List Example");
            h1.AppendChild(headingText);
            body.AppendChild(h1);

            HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");
            Text paragraphText = document.CreateTextNode("Below is a generated bullet list:");
            p.AppendChild(paragraphText);
            body.AppendChild(p);

            HTMLUListElement ul = (HTMLUListElement)document.CreateElement("ul");
            foreach (string item in items)
            {
                HTMLLIElement li = (HTMLLIElement)document.CreateElement("li");
                Text liText = document.CreateTextNode(item);
                li.AppendChild(liText);
                ul.AppendChild(li);
            }
            body.AppendChild(ul);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}