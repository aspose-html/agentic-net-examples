// Load HTML from a stream, modify its DOCTYPE declaration, and write back to a new stream.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
            using (MemoryStream inputStream = new MemoryStream(htmlBytes))
            {
                // Load HTML from stream
                using (HTMLDocument document = new HTMLDocument(inputStream, "about:blank"))
                {
                    // Create a new DOCTYPE (e.g., XHTML Transitional)
                    var newDoctype = document.CreateDocumentType(
                        "html",
                        "-//W3C//DTD XHTML 1.0 Transitional//EN",
                        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd",
                        "");

                    // Replace existing DOCTYPE or append if none
                    if (document.Doctype != null)
                    {
                        document.ReplaceChild(newDoctype, document.Doctype);
                    }
                    else
                    {
                        document.AppendChild(newDoctype);
                    }

                    // Save modified document to a temporary file
                    string tempFile = Path.Combine(Path.GetTempPath(), "modified.html");
                    document.Save(tempFile);

                    // Load the saved file into a new MemoryStream
                    byte[] modifiedBytes = File.ReadAllBytes(tempFile);
                    using (MemoryStream outputStream = new MemoryStream(modifiedBytes))
                    {
                        outputStream.Position = 0;
                        // Example usage of the output stream (e.g., display size)
                        Console.WriteLine("Modified HTML stream length: " + outputStream.Length);
                    }

                    // Clean up temporary file
                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}