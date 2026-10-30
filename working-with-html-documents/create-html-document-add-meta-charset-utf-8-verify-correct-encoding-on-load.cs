// Create an HTML document, add a meta charset UTF‑8, and verify correct encoding on load.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body>Hello</body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            string outputPath = "output.html";

            using (System.IO.MemoryStream inputStream = new System.IO.MemoryStream(bytes))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
                {
                    Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");
                    bool charsetCorrect = false;
                    foreach (Aspose.Html.Dom.Element meta in metaElements)
                    {
                        if (meta.GetAttribute("charset") == "UTF-8")
                        {
                            charsetCorrect = true;
                            meta.SetAttribute("charset", "UTF-8");
                        }
                    }

                    System.Console.WriteLine(charsetCorrect ? "Meta charset UTF-8 verified." : "Meta charset not found or incorrect.");

                    document.Save(outputPath);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}