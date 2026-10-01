// Insert a new meta tag for character encoding into the head section of the HTML document.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><head></head><body><p>Hello, World!</p></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            string outputPath = "output.html";

            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                Aspose.Html.HTMLElement meta = document.CreateElement("meta") as Aspose.Html.HTMLElement;
                meta.SetAttribute("charset", "utf-8");
                head.AppendChild(meta);

                document.Save(outputPath);
                System.Console.WriteLine("Meta tag inserted and HTML saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}