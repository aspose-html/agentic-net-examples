// Create an HTML document, add a meta charset UTF‑8, and verify correct encoding on load.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><p>Hello</p></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var metaElements = document.GetElementsByTagName("meta");
                bool charsetCorrect = false;
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    string charset = meta.GetAttribute("charset");
                    if (!string.IsNullOrEmpty(charset))
                    {
                        if (charset.Equals("UTF-8", StringComparison.OrdinalIgnoreCase))
                        {
                            charsetCorrect = true;
                        }
                        else
                        {
                            meta.SetAttribute("charset", "UTF-8");
                        }
                    }
                }
                Console.WriteLine(charsetCorrect ? "Meta charset is UTF-8." : "Meta charset corrected to UTF-8.");
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}