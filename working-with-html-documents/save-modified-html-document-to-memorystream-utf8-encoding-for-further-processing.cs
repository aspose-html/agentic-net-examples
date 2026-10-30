// Save a modified HTMLDocument to a MemoryStream with UTF‑8 encoding for further processing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello</h1></body></html>";
            string baseUrl = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);

            Aspose.Html.Dom.Element paragraph = document.CreateElement("p");
            paragraph.TextContent = "Added paragraph";
            document.Body.AppendChild(paragraph);

            string updatedHtml = document.DocumentElement.OuterHTML;
            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(updatedHtml);

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            memoryStream.Write(utf8Bytes, 0, utf8Bytes.Length);
            memoryStream.Position = 0;

            // Example of further processing: read back the content
            byte[] resultBytes = memoryStream.ToArray();
            string resultString = System.Text.Encoding.UTF8.GetString(resultBytes);
            System.Console.WriteLine(resultString);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}