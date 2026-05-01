// Create a text node with Unicode characters, append to a div, and save the document as UTF-8 HTML.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path
            string outputPath = "output.html";

            // Create a new HTML document (lifecycle managed by using)
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a <div> element
                HTMLElement div = (HTMLElement)document.CreateElement("div");

                // Create a text node containing Unicode characters
                Text text = document.CreateTextNode("Unicode test: 測試, тест, اختبار");

                // Append the text node to the <div>
                div.AppendChild(text);

                // Append the <div> to the document body
                document.Body.AppendChild(div);

                // Save the document as UTF-8 HTML
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}