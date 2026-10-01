// Extract the value of the charset meta tag and ensure it matches the file encoding.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "result.html";

            // Create a sample HTML file with a mismatched charset declaration.
            string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Test</title></head><body>Hello World</body></html>";
            System.IO.File.WriteAllText(sourcePath, sampleHtml, System.Text.Encoding.GetEncoding("windows-1252"));

            // Read the file using its actual encoding.
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding("windows-1252"));

            // Load the HTML document from a memory stream.
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    string charset = meta.GetAttribute("charset");
                    if (!string.IsNullOrEmpty(charset))
                    {
                        string actualEncoding = System.Text.Encoding.GetEncoding("windows-1252").WebName;
                        if (!string.Equals(charset, actualEncoding, System.StringComparison.OrdinalIgnoreCase))
                        {
                            meta.SetAttribute("charset", actualEncoding);
                        }
                    }
                }

                document.Save(outputPath);
            }

            System.Console.WriteLine("Processing completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}