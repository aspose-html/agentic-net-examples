// Load an HTML file, replace all <i> tags with <em> tags, and save the updated file.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body><p>Hello World</p></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var document = new Aspose.Html.HTMLDocument(inputStream, string.Empty))
                {
                    var metaElements = document.GetElementsByTagName("meta");
                    foreach (Aspose.Html.Dom.Element meta in metaElements)
                    {
                        if (meta.GetAttribute("name") == "viewport")
                        {
                            meta.SetAttribute("content", "width=device-width, initial-scale=2.0");
                        }
                    }

                    string outputPath = "output.html";
                    document.Save(outputPath);
                    Console.WriteLine($"Document saved to {Path.GetFullPath(outputPath)}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}