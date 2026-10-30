// Insert a new meta tag for character encoding into the head section of the HTML document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                var head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                var meta = document.CreateElement("meta") as Aspose.Html.Dom.Element;
                meta.SetAttribute("charset", "UTF-8");
                head.AppendChild(meta);

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Meta charset tag inserted. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}