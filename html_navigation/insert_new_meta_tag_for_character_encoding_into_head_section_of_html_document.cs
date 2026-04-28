// Insert a new meta tag for character encoding into the head section of the HTML document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            string htmlContent = File.ReadAllText(sourcePath, System.Text.Encoding.UTF8);
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            Element meta = document.CreateElement("meta");
            meta.SetAttribute("charset", "utf-8");
            head.AppendChild(meta);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}