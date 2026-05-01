// Load HTML from a stream, modify its DOCTYPE declaration, and write back to a new stream.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent));

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputStream, "");

            string html = document.DocumentElement.OuterHTML;

            string newDoctype = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
            string modifiedHtml = Regex.Replace(html, @"<!DOCTYPE[^>]*>", newDoctype, RegexOptions.IgnoreCase);

            byte[] bytes = Encoding.UTF8.GetBytes(modifiedHtml);
            MemoryStream outputStream = new MemoryStream(bytes);

            outputStream.Position = 0;
            using (StreamReader reader = new StreamReader(outputStream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}