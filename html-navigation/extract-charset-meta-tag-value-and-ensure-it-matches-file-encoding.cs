// Extract the value of the charset meta tag and ensure it matches the file encoding.

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
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"iso-8859-1\"><title>Test</title></head><body>Hello</body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            string outputPath = "output.html";

            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var metaElements = document.GetElementsByTagName("meta");

                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    string charset = meta.GetAttribute("charset");
                    if (!string.IsNullOrEmpty(charset))
                    {
                        string expected = Encoding.UTF8.WebName; // "utf-8"
                        if (!string.Equals(charset, expected, StringComparison.OrdinalIgnoreCase))
                        {
                            meta.SetAttribute("charset", expected);
                        }
                    }
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}