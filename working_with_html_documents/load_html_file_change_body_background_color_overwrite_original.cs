// Load an HTML file from disk, change body background color, and overwrite the original file.

using System;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "input.html";
            HTMLDocument document = new HTMLDocument(filePath);
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "#ADD8E6";
            document.Save(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}