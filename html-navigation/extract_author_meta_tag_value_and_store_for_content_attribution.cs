// Extract the value of the author meta tag and store it for content attribution.

using System;
using System.Text;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"author\" content=\"John Doe\"></head><body></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, string.Empty))
            {
                var metaElements = document.GetElementsByTagName("meta");
                string author = string.Empty;

                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "author")
                    {
                        author = meta.GetAttribute("content");
                        break;
                    }
                }

                System.Console.WriteLine("Author meta tag value: " + author);

                string outputPath = "output.html";
                document.Save(outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}