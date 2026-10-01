// Add a nofollow attribute to external links to control search engine crawling.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.html";
                string outputPath = "output.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    string sampleHtml = "<html><head><title>Test</title></head><body><a href=\"https://www.example.com\">External Link</a> <a href=\"/local/page.html\">Local Link</a></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Aspose.Html.Dom.Element link = (Aspose.Html.Dom.Element)links[i];
                        string href = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href) && (href.StartsWith("http://") || href.StartsWith("https://")))
                        {
                            link.SetAttribute("rel", "nofollow");
                        }
                    }

                    document.Save(outputPath);
                    System.Console.WriteLine($"Processed document saved to {outputPath}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}